
/// ------------------------------------------------------------------------------------ 
/// 
/// This script is an asset for the fake console used in my game.
/// Tutorial to put it all together is available at this adress: 
/// https://wwww.packtpub.com/books/content/making-game-console-unity-part-1
/// 
/// I've tried different method, but this one seems to be the most efficient.
/// It takes a little time to understand how it works, but at the end it's pretty simple.
/// 
/// My code that I added in this script is at the end in the section AUTOMATIC COMMAND,
/// MY COMMANDS and where I need to register my commands.
/// 
/// CREDIT :
/// Handles parsing and execution of console commands, as well as collecting log output.
/// Copyright (c) 2014-2015 Eliot Lash
/// 
/// ------------------------------------------------------------------------------------ 

using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text;

public delegate void CommandHandler(string[] args);

public class ConsoleController {

	#region Event declarations
	// Used to communicate with ConsoleView
	public delegate void LogChangedHandler(string[] log);
	public event LogChangedHandler logChanged;

	public delegate void VisibilityChangedHandler(bool visible);
	public event VisibilityChangedHandler visibilityChanged;
	#endregion

	/// <summary>
	/// Object to hold information about each command
	/// </summary>
	class CommandRegistration {
		public string command { get; private set; }
		public CommandHandler handler { get; private set; }
		public string help { get; private set; }

		public CommandRegistration(string command, CommandHandler handler, string help) {
			this.command = command;
			this.handler = handler;
			this.help = help;
		}
	}

	/// <summary>
	/// How many log lines should be retained?
	/// Note that strings submitted to appendLogLine with embedded newlines will be counted as a single line.
	/// </summary>
	const int scrollbackSize = 1000;

	Queue<string> scrollback = new Queue<string>(scrollbackSize);
	List<string> commandHistory = new List<string>();
	Dictionary<string, CommandRegistration> commands = new Dictionary<string, CommandRegistration>();

	public string[] log { get; private set; } //Copy of scrollback as an array for easier use by ConsoleView

	const string repeatCmdName = "!!"; //Name of the repeat command, constant since it needs to skip these if they are in the command history

	public ConsoleController() {
		//When adding commands, you must add a call below to registerCommand() with its name, implementation method, and help text.
		registerCommand("help", help, "Print this help.");
		registerCommand(repeatCmdName, repeatCommand, "Repeat last command.");
		registerCommand("r.1", rOne, "Set the canon on the row number 1");
		registerCommand("r.2", rTwo, "Set the canon on the row number 2");
		registerCommand("r.3", rThree, "Set the canon on the row number 3");
		registerCommand("r.4", rFour, "Set the canon on the row number 4");
		registerCommand("r.5", rFive, "Set the canon on the row number 5");
		registerCommand("r.6", rSix, "Set the canon on the row number 6");
		registerCommand("r.7", rSeven, "Set the canon on the row number 7");
		registerCommand("r.8", rEight, "Set the canon on the row number 8");
		registerCommand("r.9", rNine, "Set the canon on the row number 9");
		registerCommand("fire", rNine, "Fire the cannon on the selected row");
	}

	void registerCommand(string command, CommandHandler handler, string help) {
		commands.Add(command, new CommandRegistration(command, handler, help));
	}

	public void appendLogLine(string line) {
		Debug.Log(line);

		if (scrollback.Count >= ConsoleController.scrollbackSize) {
			scrollback.Dequeue();
		}
		scrollback.Enqueue(line);

		log = scrollback.ToArray();
		if (logChanged != null) {
			logChanged(log);
		}
	}

	public void runCommandString(string commandString) {
		appendLogLine("// " + commandString);

		string[] commandSplit = parseArguments(commandString);
		string[] args = new string[0];
		if (commandSplit.Length < 1) {
			appendLogLine(string.Format("Unable to process command '{0}'", commandString));
			return;

		}  else if (commandSplit.Length >= 2) {
			int numArgs = commandSplit.Length - 1;
			args = new string[numArgs];
			Array.Copy(commandSplit, 1, args, 0, numArgs);
		}
		runCommand(commandSplit[0].ToLower(), args);
		commandHistory.Add(commandString);
	}

	public void runCommand(string command, string[] args) {
		CommandRegistration reg = null;
		if (!commands.TryGetValue(command, out reg)) {
			appendLogLine(string.Format("Unknown command '{0}', type 'help' for list.", command));
		}  else {
			if (reg.handler == null) {
				appendLogLine(string.Format("Unable to process command '{0}', handler was null.", command));
			}  else {
				reg.handler(args);
			}
		}
	}

	static string[] parseArguments(string commandString)
	{
		LinkedList<char> parmChars = new LinkedList<char>(commandString.ToCharArray());
		bool inQuote = false;
		var node = parmChars.First;
		while (node != null)
		{
			var next = node.Next;
			if (node.Value == '"') {
				inQuote = !inQuote;
				parmChars.Remove(node);
			}
			if (!inQuote && node.Value == ' ') {
				node.Value = '\n';
			}
			node = next;
		}
		char[] parmCharsArr = new char[parmChars.Count];
		parmChars.CopyTo(parmCharsArr, 0);
		return (new string(parmCharsArr)).Split(new char[] {'\n'} , StringSplitOptions.RemoveEmptyEntries);
	}
		
	// ----------------------------------------------------------------------
	// AUTOMATIC MESSAGES
	// ----------------------------------------------------------------------
	public void bootUp () {
		appendLogLine ("Welcome to bubble puzzle (temporary name).");
		appendLogLine ("A game by Deep Dream Co. and distributed for Saturn Enterprise.");
		appendLogLine (" ");
		appendLogLine ("This game plays with command lines.");
		appendLogLine ("Enter help to see a list of all actions you can do.");

	}



	// ----------------------------------------------------------------------
	// MY COMMANDS
	// ----------------------------------------------------------------------
	#region Command handlers

	// Reference to the cannon




	// Display the help list ------------------------------------------------
	void help(string[] args) {
		foreach(CommandRegistration reg in commands.Values) {
			appendLogLine(string.Format("{0}: {1}", reg.command, reg.help));
		}
	}

	void repeatCommand(string[] args) {
		for (int cmdIdx = commandHistory.Count - 1; cmdIdx >= 0; --cmdIdx) {
			string cmd = commandHistory[cmdIdx];
			if (String.Equals(repeatCmdName, cmd)) {
				continue;
			}
			runCommandString(cmd);
			break;
		}
	}




	// Fire the cannon -----------------------------------------------------
	void fire (string[] args) {
		// Set the cannon to row 1
		GameObject m_cannon = GameObject.FindGameObjectWithTag("Cannon");
		cannonController cannonScript = m_cannon.GetComponent<cannonController>();
		cannonScript.shoot();
		appendLogLine ("FIRE! The cannon just shot on the selected row");
	}




	// Change the current target row of the cannon ------------------------- 
	void rOne (string[] args) {
		// Set the cannon to row 1
		GameObject m_cannon = GameObject.FindGameObjectWithTag("Cannon");
		cannonController cannonScript = m_cannon.GetComponent<cannonController>();
		cannonScript.changeAngle(1);
		appendLogLine ("New cannon position : Set to row number 1");
	}

	void rTwo (string[] args) {
		// Set the cannon to row 2
		GameObject m_cannon = GameObject.FindGameObjectWithTag("Cannon");
		cannonController cannonScript = m_cannon.GetComponent<cannonController>();
		cannonScript.changeAngle(2);
		appendLogLine ("New cannon position : Set to row number 2");
	}

	void rThree (string[] args) {
		// Set the cannon to row 3
		GameObject m_cannon = GameObject.FindGameObjectWithTag("Cannon");
		cannonController cannonScript = m_cannon.GetComponent<cannonController>();
		cannonScript.changeAngle(3);
		appendLogLine ("New cannon position : Set to row number 3");
	}

	void rFour (string[] args) {
		// Set the cannon to row 4
		GameObject m_cannon = GameObject.FindGameObjectWithTag("Cannon");
		cannonController cannonScript = m_cannon.GetComponent<cannonController>();
		cannonScript.changeAngle(4);
		appendLogLine ("New cannon position : Set to row number 4");
	}

	void rFive (string[] args) {
		// Set the cannon to row 5
		GameObject m_cannon = GameObject.FindGameObjectWithTag("Cannon");
		cannonController cannonScript = m_cannon.GetComponent<cannonController>();
		cannonScript.changeAngle(5);
		appendLogLine ("New cannon position : Set to row number 5");
	}

	void rSix (string[] args) {
		// Set the cannon to row 6
		GameObject m_cannon = GameObject.FindGameObjectWithTag("Cannon");
		cannonController cannonScript = m_cannon.GetComponent<cannonController>();
		cannonScript.changeAngle(6);
		appendLogLine ("New cannon position : Set to row number 6");
	}

	void rSeven (string[] args) {
		// Set the cannon to row 7
		GameObject m_cannon = GameObject.FindGameObjectWithTag("Cannon");
		cannonController cannonScript = m_cannon.GetComponent<cannonController>();
		cannonScript.changeAngle(7);
		appendLogLine ("New cannon position : Set to row number 7");
	}

	void rEight (string[] args) {
		// Set the cannon to row 8
		GameObject m_cannon = GameObject.FindGameObjectWithTag("Cannon");
		cannonController cannonScript = m_cannon.GetComponent<cannonController>();
		cannonScript.changeAngle(8);
		appendLogLine ("New cannon position : Set to row number 8");
	}

	void rNine (string[] args) {
		// Set the cannon to row 9
		GameObject m_cannon = GameObject.FindGameObjectWithTag("Cannon");
		cannonController cannonScript = m_cannon.GetComponent<cannonController>();
		cannonScript.changeAngle(9);
		appendLogLine ("New cannon position : Set to row number 9");
	}
		

	#endregion
}