# UniGitCommitHash

Git のコミットハッシュを管理するスクリプトを生成するエディタ拡張

## 使用例

```cs
var outputPath = "Assets/Scripts/GitCommitHash.cs";

var template = $@"public static class GitCommitHash
{{
    public const string COMMIT_HASH       = ""{GitCommitHashCodeGenerator.COMMIT_HASH_TAG}"";
    public const string SHORT_COMMIT_HASH = ""{GitCommitHashCodeGenerator.SHORT_COMMIT_HASH_TAG}"";
}}";

GitCommitHashCodeGenerator.Generate( outputPath, template );
```
