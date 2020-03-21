using System;

using Godot;

using Sentry;
using Sentry.Protocol;


public class SentryController : Node {

	public override void _Ready() {

		SentrySdk.Init(o => {
			o.Dsn = new Dsn("https://451cf9b0fd9e4f0294a0d15b6c36bce2@sentry.io/5170198");
		});

		SentrySdk.ConfigureScope(s => {
			s.SetTag("os.name", OS.GetName());
			s.SetTag("os.model", OS.GetModelName());
		});

		SentrySdk.AddBreadcrumb(
			message: "Sentry initialized",
			category: "init",
			level: BreadcrumbLevel.Info);
	}

	public override void _Notification(int what) {

		if (what == MainLoop.NotificationWmQuitRequest) {
			SentrySdk.CaptureMessage("App Quit!");
		}
	}
}
