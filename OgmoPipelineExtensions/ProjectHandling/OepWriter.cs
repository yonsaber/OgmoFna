using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using OgmoPipelineExtensions.ContentItems;

namespace OgmoPipelineExtensions
{
    [ContentTypeWriter]
    public class OepWriter : ContentTypeWriter<ProjectContent>
    {
        protected override void Write(ContentWriter output, ProjectContent projectContent)
        {
            // TODO: Set this up to change
            output.Write("XML");

            // Not vital, but having this information can help with debugging etc
            output.Write(projectContent.VersionNumber);
            output.Write(projectContent.Name);

            // Settings
            output.Write(projectContent.BackgroundColor);
            output.Write(projectContent.GridColor);
            output.Write(projectContent.LevelDefaultSize);
            output.Write(projectContent.LevelMinimumSize);
            output.Write(projectContent.LevelMaximumSize);
            output.Write(projectContent.AngleMode);
            output.Write(projectContent.CameraEnabled);
            output.Write(projectContent.CameraSize);
            output.Write(projectContent.ExportCameraPosition);

            // LevelValueDefinitions
            //output.Write(projectContent.LevelValueDefinitions.Count);

            //if (projectContent.LevelValueDefinitions.Count > 0)
            //{
            //    foreach (LevelValueContent levelValueContent in projectContent.LevelValueDefinitions)
            //    {
            //        output.Write(levelValueContent.Name);
            //    }
            //}

            // LayerDefinitions
            output.Write(projectContent.LayerDefinitions.Count);

            if (projectContent.LayerDefinitions.Count > 0)
            {
                foreach (LayerDefinitionContent layerDefinition in projectContent.LayerDefinitions)
                {
                    output.Write(layerDefinition.Name);
                    output.Write(layerDefinition.Grid);
                    output.Write(layerDefinition.ScrollFactor);
                    output.Write(layerDefinition.Color);
                    output.Write(layerDefinition.ExportMode.ToString());
                }
            }

            // Tilesets
            output.Write(projectContent.Tilesets.Count);

            if (projectContent.Tilesets.Count > 0)
            {
                foreach (TilesetContent tilesetContent in projectContent.Tilesets)
                {
                    output.Write(tilesetContent.Name);
                    output.WriteExternalReference(tilesetContent.TextureReference);
                    output.Write(tilesetContent.FilePath);
                    output.Write(tilesetContent.TileSize);
                    output.Write(tilesetContent.TileStep);
                }
            }

            // EntityDefinitions
            output.Write(projectContent.EntityDefinitions.Count);

            if (projectContent.EntityDefinitions.Count > 0)
            {
                foreach (EntityDefinitionContent entityDefinition in projectContent.EntityDefinitions)
                {
                    output.Write(entityDefinition.Name);
                    output.Write(entityDefinition.Limit);
                    output.Write(entityDefinition.ResizableX);
                    output.Write(entityDefinition.ResizableY);
                    output.Write(entityDefinition.Rotatable);
                    output.Write(entityDefinition.RotateIncrement);
                    output.Write(entityDefinition.Size);
                    output.Write(entityDefinition.Origin);
                }
            }

            output.Write("End");
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return "OgmoGame.OgmoProjectReader, OgmoGame";
        }

        public override string GetRuntimeType(TargetPlatform targetPlatform)
        {
            return "OgmoGame.OgmoProject, OgmoGame";
        }
    }
}
