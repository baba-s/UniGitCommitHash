using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace UniGitCommitHash.Example
{
	/// <summary>
	/// UniGitCommitHash のサンプル
	/// </summary>
	[InitializeOnLoad]
	public sealed class GitCommitHashExample : IPreprocessBuildWithReport
	{
		//================================================================================
		// 定数
		//================================================================================
		// Git のコミットハッシュを管理するスクリプトの出力先
		private const string OUTPUT_PATH = "Assets/Scripts/GitCommitHash.cs";
		
		//================================================================================
		// 定数（static readonly）
		//================================================================================
		// Git のコミットハッシュを管理するスクリプトのテンプレート
		private static readonly string TEMPLATE = $@"public static class GitCommitHash
{{
    public const string COMMIT_HASH       = ""{GitCommitHashCodeGenerator.COMMIT_HASH_TAG}"";
    public const string SHORT_COMMIT_HASH = ""{GitCommitHashCodeGenerator.SHORT_COMMIT_HASH_TAG}"";
}}";
		
		//================================================================================
		// プロパティ
		//================================================================================
		public int callbackOrder => 0;
		
		//================================================================================
		// 関数
		//================================================================================
		/// <summary>
		/// ビルド前に呼び出されます
		/// </summary>
		public void OnPreprocessBuild( BuildReport report )
		{
			Generate();
		}

		//================================================================================
		// 関数（static）
		//================================================================================
		/// <summary>
		/// コンストラクタ
		/// </summary>
		static GitCommitHashExample()
		{
			GitCommitHashMenu.OnForceGenerate += () => Generate();
		}

		/// <summary>
		/// Git のコミットハッシュを管理するスクリプトを生成します
		/// </summary>
		private static void Generate()
		{
			GitCommitHashCodeGenerator.Generate
			(
				outputPath: OUTPUT_PATH,
				template: TEMPLATE
			);
		}
	}
}