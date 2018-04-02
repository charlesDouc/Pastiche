
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
		registerCommand("goright", goRight, "Move to the right.");
		registerCommand("goleft", goLeft, "Move to the left.");
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

	
	// Move to the right -----------------------------------------------------
	void goRight (string[] args) {
		// Get all the players object active in the scene
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

		// Activate the movement for each player instance
		if (players != null) {
			for (int i = 0; i < players.Length; i++) {
				playerController playersScript = players[i].GetComponent<playerController>();
				playersScript.goRight();
			}
		}

		// Write in the console
		appendLogLine ("Start Movement Right.");
	}


	// Move to the left -----------------------------------------------------
	void goLeft (string[] args) {
		// Get all the players object active in the scene
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

		// Activate the movement for each player instance
		if (players != null) {
			for (int i = 0; i < players.Length; i++) {
				playerController playersScript = players[i].GetComponent<playerController>();
				playersScript.goLeft();
			}
		}

		// Write in the console
		appendLogLine ("Start Movement **Left**.");
	}




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


	#endregion
}