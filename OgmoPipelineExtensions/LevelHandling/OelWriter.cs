using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using OgmoPipelineExtensions.ContentItems;

namespace OgmoPipelineExtensions
{
    [ContentTypeWriter]
    public class OelWriter : ContentTypeWriter<LevelContent>
    {
        protected override void Write(ContentWriter output, LevelContent value)
        {
            // Project
            output.WriteExternalReference(value.ProjectReference);
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return "OgmoGame.OgmoLevelReader, OgmoGame";
        }

        public override string GetRuntimeType(TargetPlatform targetPlatform)
        {
            return "OgmoGame.OgmoLevel, OgmoGame";
        }
    }
}
