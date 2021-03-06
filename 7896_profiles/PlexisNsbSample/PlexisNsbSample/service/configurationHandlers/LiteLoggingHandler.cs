using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using NServiceBus;

namespace PlexisNsbSample
{
	public class LiteLoggingHandler : IConfigureLoggingForProfile<Lite>
	{
		/// <summary>
		/// Performs all logging configuration.
		/// </summary>
		public void Configure(IConfigureThisEndpoint specifier)
		{
			ColoredConsoleAppender appender = null;

			SetLoggingLibrary.Log4Net<ColoredConsoleAppender>(
				null,
				(a) =>
					{
						a.Layout = new PatternLayout("%d [%t] %-5p %c\n\t%m%n");
						a.Threshold = Level.Debug;
						PrepareColors(a);
						appender = a;
					}
			);

			var repo = LogManager.GetAllRepositories()[0];

			var nsb = (Logger) repo.GetLogger("NServiceBus");
			var nsbSerializer = (Logger) repo.GetLogger("NServiceBus.Serializers");
			var nhibernate = (Logger) repo.GetLogger("NHibernate");
			var plexis = (Logger) repo.GetLogger("Plexis");

			nsb.Level = Level.Debug;
			nsbSerializer.Level = Level.Warn;
			nhibernate.Level = Level.Warn;
			plexis.Level = Level.Debug;
		}

		///<summary>
		/// Sets default colors for a ColoredConsoleAppender
		///</summary>
		///<param name="a"></param>
		public static void PrepareColors(ColoredConsoleAppender a)
		{
			a.AddMapping(
				new ColoredConsoleAppender.LevelColors
				{
					Level = Level.Debug,
					ForeColor = ColoredConsoleAppender.Colors.White
				});
			a.AddMapping(
				new ColoredConsoleAppender.LevelColors
				{
					Level = Level.Info,
					ForeColor = ColoredConsoleAppender.Colors.Green
				});
			a.AddMapping(
				new ColoredConsoleAppender.LevelColors
				{
					Level = Level.Warn,
					ForeColor = ColoredConsoleAppender.Colors.Yellow | ColoredConsoleAppender.Colors.HighIntensity
				});
			a.AddMapping(
				new ColoredConsoleAppender.LevelColors
				{
					Level = Level.Error,
					ForeColor = ColoredConsoleAppender.Colors.Red | ColoredConsoleAppender.Colors.HighIntensity
				});
		}
	}
}