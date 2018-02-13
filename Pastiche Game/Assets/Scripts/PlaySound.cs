using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

public class ExamplePlayableBehaviour : PlayableBehaviour
{
	void Start()
	{
		PlayableGraph graph = PlayableGraph.Create();
		AnimationMixerPlayable mixer = AnimationMixerPlayable.Create(graph, 1);

		// Calling method PlayableExtensions.SetDuration on AnimationMixerPlayable as if it was an instance method.
		mixer.SetDuration(10);

		// The line above is the same as calling directly PlayableExtensions.SetDuration, but it is more compact and readable.
		PlayableExtensions.SetDuration(mixer, 10);
	}
}