# UniGitCommitHash

Git のコミットハッシュを管理するスクリプトを生成するエディタ拡張

![](https://img.shields.io/badge/Unity-2019.2%2B-red.svg)
![](https://img.shields.io/badge/.NET-4.x-orange.svg)
[![](https://img.shields.io/github/license/baba-s/UniGitCommitHash.svg)](https://github.com/baba-s/UniGitCommitHash/blob/master/LICENSE.md)

## 使用例

```cs
var outputPath = "Assets/Scripts/GitCommitHash.cs";

var option = new CommitLogOption
(
	count: 10,
	isNoMerges: false,
	format: "%h %cd %cn %s"
);

var template = $@"public static class GitCommitHash
{{
    public const string COMMIT_HASH       = ""{GitCommitHashCodeGenerator.COMMIT_HASH_TAG}"";
    public const string SHORT_COMMIT_HASH = ""{GitCommitHashCodeGenerator.SHORT_COMMIT_HASH_TAG}"";
    public const string COMMIT_LOG_TAG    = @""{GitCommitHashCodeGenerator.COMMIT_LOG_TAG}"";
}}";

GitCommitHashCodeGenerator.Generate( outputPath, template, option );
```
