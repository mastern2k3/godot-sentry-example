using System;

using Godot;

using Sentry;


public class App : Node2D {

	public override void _Ready() {
		SentrySdk.CaptureMessage("App Ready!");
	}

	private void _on_AwesomeButton_pressed() {
		SentrySdk.AddBreadcrumb("Awesome button clicked");
	}

	private void _on_CrashButton_pressed() {
		throw new Exception("Oh lord jesus it's a fire!");
	}
}
