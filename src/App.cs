using System;

using Godot;

using Sentry;


public class App : Node2D {

	public override void _Ready() {

		SentrySdk.CaptureMessage("App Ready!");
	}
}
