﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DragonLib.CLI;
using Snuggle.Core.Meta;

namespace Snuggle.Headless;

[SuppressMessage("ReSharper", "PropertyCanBeMadeInitOnly.Global")]
public record SnuggleFlags : ICLIFlags {
    [CLIFlag("no-mesh", Aliases = new[] { "m" }, Category = "General Options", Default = false, Help = "Do not export rigid meshes (can still export through game objects)")]
    public bool NoMesh { get; set; }

    [CLIFlag("no-rigged-meshes", Aliases = new[] { "s" }, Category = "General Options", Default = false, Help = "Do not export rigged meshes (can still export through game objects)")]
    public bool NoSkinnedMesh { get; set; }

    [CLIFlag("no-game-object", Aliases = new[] { "b" }, Category = "General Options", Default = false, Help = "Do not export game objects")]
    public bool NoGameObject { get; set; }

    [CLIFlag("no-texture", Aliases = new[] { "T" }, Category = "General Options", Default = false, Help = "Do not export textures")]
    public bool NoTexture { get; set; }

    [CLIFlag("no-text", Aliases = new[] { "t" }, Category = "General Options", Default = false, Help = "Do not export text assets")]
    public bool NoText { get; set; }

    [CLIFlag("no-sprite", Aliases = new[] { "S" }, Category = "General Options", Default = false, Help = "Do not export sprite assets")]
    public bool NoSprite { get; set; }

    [CLIFlag("no-audio", Aliases = new[] { "A" }, Category = "General Options", Default = false, Help = "Do not export audio clip assets")]
    public bool NoAudio { get; set; }

    [CLIFlag("no-materials", Aliases = new[] { "M" }, Category = "General Options", Default = false, Help = "Do not export materials")]
    public bool NoMaterials { get; set; }

    [CLIFlag("no-vertex-color", Aliases = new[] { "c" }, Category = "General Options", Default = false, Help = "Do not write vertex colors")]
    public bool NoVertexColor { get; set; }

    [CLIFlag("no-morphs", Aliases = new[] { "O" }, Category = "General Options", Default = false, Help = "Do not write morphs")]
    public bool NoMorphs { get; set; }

    [CLIFlag("no-script", Aliases = new[] { "B" }, Category = "General Options", Default = false, Help = "Do not export MonoBehaviour data")]
    public bool NoScript { get; set; }

    [CLIFlag("data", Category = "General Options", Default = false, Help = "Do not convert, export serialization data instead")]
    public bool DataOnly { get; set; }

    [CLIFlag("dont-scan-up", Category = "General Options", Default = false, Help = "Do not scan for game object hierarchy ancestors")]
    public bool NoGameObjectHierarchyUp { get; set; }

    [CLIFlag("dont-scan-down", Category = "General Options", Default = false, Help = "Do not scan for game object hierarchy descendants")]
    public bool NoGameObjectHierarchyDown { get; set; }

    [CLIFlag("dds", Category = "General Options", Default = false, Help = "Export textures to DDS when possible, otherwise use PNG")]
    public bool WriteNativeTextures { get; set; }

    [CLIFlag("use-dxtex", Category = "General Options", Default = false, Help = "Use DirectXTex when possible (only on windows)")]
    public bool UseDirectXTex { get; set; }

    [CLIFlag("fsb", Category = "General Options", Default = false, Help = "Write original audio file formats")]
    public bool WriteNativeAudio { get; set; }

    [CLIFlag("low-memory", Category = "General Options", Default = false, Help = "Low memory mode, at the cost of performance")]
    public bool LowMemory { get; set; }

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

    [CLIFlag("output-format", Aliases = new[] { "f" }, Category = "General Options", Default = "{Type}/{Container}/{Id}_{Name}.{Ext}", Help = "Output path format")]
    public string OutputFormat { get; set; } = null!;

    [CLIFlag("containerless-output-format", Aliases = new[] { "F" }, Category = "General Options", Default = null, Help = "Output path format for objects without a container")]
    public string? ContainerlessOutputFormat { get; set; }

    [CLIFlag("output", Aliases = new[] { "o", "out" }, Category = "General Options", Help = "Path to output files to", IsRequired = true)]
    public string OutputPath { get; set; } = null!;

    [CLIFlag("name", Category = "General Options", Help = "Game Object Name/Container Path Filters", Extra = RegexOptions.CultureInvariant | RegexOptions.Compiled)]
    public List<Regex> NameFilters { get; set; } = null!;

    [CLIFlag("script", Category = "General Options", Help = "Script Class Filters", Extra = RegexOptions.CultureInvariant | RegexOptions.Compiled)]
    public List<Regex> ScriptFilters { get; set; } = null!;

    [CLIFlag("assembly", Category = "General Options", Help = "Script Assembly Filters", Extra = RegexOptions.CultureInvariant | RegexOptions.Compiled)]
    public List<Regex> AssemblyFilters { get; set; } = null!;

    [CLIFlag("id", Category = "General Options", Help = "Path ID Filters")]
    public List<long> PathIdFilters { get; set; } = null!;

    [CLIFlag("only-cab", Category = "General Options", Default = false, Help = "Only export objects with CAB paths")]
    public bool OnlyCAB { get; set; }

    [CLIFlag("paths", Category = "General Options", Positional = 0, Help = "Paths to load", IsRequired = true)]
    public List<string> Paths { get; set; } = null!;

    [CLIFlag("ignore", Category = "General Options", Help = "ClassIds to Ignore")]
    public HashSet<string> IgnoreClassIds { get; set; } = null!;

    [CLIFlag("exclusive", Category = "General Options", Help = "ClassIds to deserialize")]
    public HashSet<string> ExclusiveClassIds { get; set; } = null!;

    [CLIFlag("keepxpos", Category = "General Options", Default = false, Help = "Do not mirror mesh X position")]
    public bool KeepXPos { get; set; }

    [CLIFlag("keepxnorm", Category = "General Options", Default = false, Help = "Do not mirror mesh X normal")]
    public bool KeepXNorm { get; set; }

    [CLIFlag("keepxtan", Category = "General Options", Default = false, Help = "Do not mirror mesh X tangent")]
    public bool KeepXTan { get; set; }

    public override string ToString() {
        var sb = new StringBuilder();
        sb.AppendLine($"{nameof(SnuggleFlags)} {{");
        sb.AppendLine($"  {nameof(NoMesh)} = {(NoMesh ? "True" : "False")},");
        sb.AppendLine($"  {nameof(NoSkinnedMesh)} = {(NoSkinnedMesh ? "True" : "False")},");
        sb.AppendLine($"  {nameof(NoGameObject)} = {(NoGameObject ? "True" : "False")},");
        sb.AppendLine($"  {nameof(NoTexture)} = {(NoTexture ? "True" : "False")},");
        sb.AppendLine($"  {nameof(NoText)} = {(NoText ? "True" : "False")},");
        sb.AppendLine($"  {nameof(NoSprite)} = {(NoSprite ? "True" : "False")},");
        sb.AppendLine($"  {nameof(NoAudio)} = {(NoAudio ? "True" : "False")},");
        sb.AppendLine($"  {nameof(NoMaterials)} = {(NoMaterials ? "True" : "False")},");
        sb.AppendLine($"  {nameof(NoVertexColor)} = {(NoVertexColor ? "True" : "False")},");
        sb.AppendLine($"  {nameof(NoMorphs)} = {(NoMorphs ? "True" : "False")},");
        sb.AppendLine($"  {nameof(NoScript)} = {(NoScript ? "True" : "False")},");
        sb.AppendLine($"  {nameof(DataOnly)} = {(DataOnly ? "True" : "False")},");
        sb.AppendLine($"  {nameof(NoGameObjectHierarchyUp)} = {(NoGameObjectHierarchyUp ? "True" : "False")},");
        sb.AppendLine($"  {nameof(NoGameObjectHierarchyDown)} = {(NoGameObjectHierarchyDown ? "True" : "False")},");
        sb.AppendLine($"  {nameof(WriteNativeTextures)} = {(WriteNativeTextures ? "True" : "False")},");
        sb.AppendLine($"  {nameof(UseDirectXTex)} = {(UseDirectXTex ? "True" : "False")},");
        sb.AppendLine($"  {nameof(WriteNativeAudio)} = {(WriteNativeAudio ? "True" : "False")},");
        sb.AppendLine($"  {nameof(LowMemory)} = {(LowMemory ? "True" : "False")},");
        sb.AppendLine($"  {nameof(LooseMeshes)} = {(LooseMeshes ? "True" : "False")},");
        sb.AppendLine($"  {nameof(LooseMaterials)} = {(LooseMaterials ? "True" : "False")},");
        sb.AppendLine($"  {nameof(LooseTextures)} = {(LooseTextures ? "True" : "False")},");
        sb.AppendLine($"  {nameof(Recursive)} = {(Recursive ? "True" : "False")},");
        sb.AppendLine($"  {nameof(Game)} = {Game:G},");
        sb.AppendLine($"  {nameof(OutputFormat)} = {OutputFormat},");
        sb.AppendLine($"  {nameof(ContainerlessOutputFormat)} = {ContainerlessOutputFormat ?? "null"},");
        sb.AppendLine($"  {nameof(OutputPath)} = {OutputPath},");
        sb.AppendLine($"  {nameof(NameFilters)} = [{string.Join(", ", NameFilters.Select(x => x.ToString()))}],");
        sb.AppendLine($"  {nameof(ScriptFilters)} = [{string.Join(", ", ScriptFilters.Select(x => x.ToString()))}],");
        sb.AppendLine($"  {nameof(AssemblyFilters)} = [{string.Join(", ", AssemblyFilters.Select(x => x.ToString()))}],");
        sb.AppendLine($"  {nameof(PathIdFilters)} = [{string.Join(", ", PathIdFilters.Select(x => x.ToString()))}],");
        sb.AppendLine($"  {nameof(OnlyCAB)} = {(OnlyCAB ? "True" : "False")},");
        sb.AppendLine($"  {nameof(Paths)} = [{string.Join(", ", Paths)}],");
        sb.AppendLine($"  {nameof(IgnoreClassIds)} = [{string.Join(", ", IgnoreClassIds)}],");
        sb.AppendLine($"  {nameof(ExclusiveClassIds)} = [{string.Join(", ", ExclusiveClassIds)}],");
        sb.AppendLine($"  {nameof(KeepXPos)} = {(KeepXPos ? "True" : "False")},");
        sb.AppendLine($"  {nameof(KeepXNorm)} = {(KeepXNorm ? "True" : "False")},");
        sb.AppendLine($"  {nameof(KeepXTan)} = {(KeepXTan ? "True" : "False")}");
        sb.Append('}');
        return sb.ToString();
    }
}
