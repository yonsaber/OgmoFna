using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Framework.Content.Pipeline.Builder;
using OgmoPipelineExtension;
using OgmoPipelineExtension.ContentItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PipelineConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting");

            var manager = new PipelineManager("", "../bin/Debug/Content", "obj")
            {
                Logger = new TestContentBuildLogger()
            };

            var buildEvent = new PipelineBuildEvent();

            var pipelineImporterContext = new PipelineImporterContext(manager);

            var pipelineProcessorContext = new PipelineProcessorContext(manager, buildEvent);

            Console.WriteLine("Running OepImporter");

            OepImporter oepImporter = new OepImporter();
            OepContent oepContent = oepImporter.Import(
                "..\\..\\..\\levels\\newProject.oep",
                pipelineImporterContext
            );

            Console.WriteLine("Complete... Running OepProcessor");

            OepProcessor oepProcessor = new OepProcessor();
            oepProcessor.Process(oepContent, pipelineProcessorContext);

            Console.WriteLine("Complete... Running OelImporter");

            OelImporter oelImporter = new OelImporter();
            OelContent oelContent = oelImporter.Import(
                "..\\..\\..\\levels\\newLevel.oel",
                pipelineImporterContext
            );

            Console.WriteLine("Complete... Running OelProcessor");

            OelProcessor oelProcessor = new OelProcessor();
            oelProcessor.Process(oelContent, pipelineProcessorContext);

            Console.ReadLine();
        }
    }

    class TestContentBuildLogger : ContentBuildLogger
    {
        public override void LogImportantMessage(string message, params object[] messageArgs)
        {
            Console.WriteLine($"[IMPORTANT]\n\tMessage: {message}\n\tArgs: {Join(messageArgs, ",")}");
        }

        public override void LogMessage(string message, params object[] messageArgs)
        {
            Console.WriteLine($"[  DEBUG  ]\n\tMessage: {message}\n\tArgs: {Join(messageArgs, ",")}");
        }

        public override void LogWarning(string helpLink, ContentIdentity contentIdentity, string message, params object[] messageArgs)
        {
            Console.WriteLine($"[ WARNING ]\n\tMessage: {message}\n\tArgs: {Join(messageArgs, ",")}\n\tHelp: {helpLink}\n\tIdentity: {contentIdentity.SourceFilename}");
        }

        public string Join<T>(IEnumerable<T> values, string delim)
        {
            return string.Join(delim, values.Select(v => v == null ? "null" : v.ToString()));
        }
    }
}
