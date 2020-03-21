using System;

using Godot;

using Sentry;
using Sentry.Protocol;


public class SentryController : Node {

	public override void _Ready() {

		SentrySdk.Init(o => {
			o.Dsn = new Dsn("https://451cf9b0fd9e4f0294a0d15b6c36bce2@sentry.io/5170198");
		});

		// AppDomain.CurrentDomain.UnhandledException += _UnhandledException;

		SentrySdk.ConfigureScope(s => {
			s.SetTag("os.name", OS.GetName());
			s.SetTag("os.model", OS.GetModelName());
		});

		SentrySdk.AddBreadcrumb(
			message: "Sentry initialized",
			category: "init",
			level: BreadcrumbLevel.Info);
	}

	private void _UnhandledException(object sender, UnhandledExceptionEventArgs e) {

		var ex = e.ExceptionObject as Exception;
		if (ex == null) {

			SentrySdk.CaptureMessage(
				$"Unknown unhandled exception of type `{e.ExceptionObject.GetType()}`: {e.ExceptionObject}",
				SentryLevel.Error);
			return;
		}

		GD.PrintErr(ex.ToString());

		SentrySdk.CaptureException(ex);
	}
}
