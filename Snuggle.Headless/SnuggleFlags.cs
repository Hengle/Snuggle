﻿using System.Collections.Generic;
using System.Text.RegularExpressions;
using DragonLib.CLI;
using Snuggle.Core.Meta;

namespace Snuggle.Headless {
    public class SnuggleFlags : ICLIFlags {
        [CLIFlag("no-mesh", Aliases = new[] { "m" }, Category = "General Options", Default = false, Help = "Don't export meshes")]
        public bool NoMesh { get; set; }

        [CLIFlag("no-skin", Aliases = new[] { "s" }, Category = "General Options", Default = false, Help = "Don't export skinned meshes")]
        public bool NoSkinnedMesh { get; set; }

        [CLIFlag("no-texture", Aliases = new[] { "T" }, Category = "General Options", Default = false, Help = "Don't export textures")]
        public bool NoTexture { get; set; }

        [CLIFlag("no-text", Aliases = new[] { "t" }, Category = "General Options", Default = false, Help = "Don't export text assets")]
        public bool NoText { get; set; }

        [CLIFlag("no-materials", Aliases = new[] { "M" }, Category = "General Options", Default = false, Help = "Don't export materials")]
        public bool NoMaterials { get; set; }

        [CLIFlag("dont-scan-up", Category = "General Options", Default = false, Help = "Do not scan for game object hierarchy ancestors.")]
        public bool NoGameObjectHierarchyUp { get; set; }

        [CLIFlag("dont-scan-down", Category = "General Options", Default = false, Help = "Do not scan for game object hierarchy descendants.")]
        public bool NoGameObjectHierarchyDown { get; set; }

        [CLIFlag("dds", Category = "General Options", Default = false, Help = "Export textures to DDS when possible, otherwise use PNG")]
        public bool TextureToDDS { get; set; }

        [CLIFlag("loose-meshes", Category = "General Options", Default = false, Help = "Export mesh even if they are not part of a renderer")]
        public bool LooseMeshes { get; set; }

        [CLIFlag("loose-materials", Category = "General Options", Default = false, Help = "Export materials even if they are not part of a renderer")]
        public bool LooseMaterials { get; set; }

        [CLIFlag("loose-textures", Category = "General Options", Default = false, Help = "Export textures even if they are not part of a material")]
        public bool LooseTextures { get; set; }

        [CLIFlag("recursive", Aliases = new[] { "R" }, Category = "General Options", Default = false, Help = "Scan directories recursively for assets")]
        public bool Recursive { get; set; }

        [CLIFlag("game", Aliases = new[] { "g" }, Category = "General Options", Default = UnityGame.Default, Help = "Game specific modifications")]
        public UnityGame Game { get; set; }

        [CLIFlag("game-options", Aliases = new[] { "G" }, Category = "General Options", Default = null, Help = "Game specific modification options json")]
        public string? GameOptions { get; set; }

        [CLIFlag("output-format", Aliases = new[] { "f" }, Category = "General Options", Default = "{Type}/{Container}/{Id}_{Name}.{Ext}", Help = "Output path format")]
        public string OutputFormat { get; set; } = null!;

        [CLIFlag("output", Aliases = new[] { "o", "out" }, Category = "General Options", Help = "Path to output files to", IsRequired = true)]
        public string OutputPath { get; set; } = null!;

        [CLIFlag("name", Category = "General Options", Help = "Game Object Name/Container Path Filters", IsRequired = true)]
        public List<Regex> NameFilters { get; set; } = null!;

        [CLIFlag("id", Category = "General Options", Help = "Path ID Filters", IsRequired = true)]
        public List<long> PathIdFilters { get; set; } = null!;

        [CLIFlag("paths", Category = "General Options", Positional = 0, Help = "Paths to load", IsRequired = true)]
        public List<string> Paths { get; set; } = null!;
    }
}
