using System.IO;
using UnityEditor;

namespace UniGitCommitHash
{
	/// <summary>
	/// Git のコミットハッシュを管理するスクリプトを生成するためのクラス
	/// </summary>
	public static class GitCommitHashCodeGenerator
	{
		//================================================================================
		// 定数
		//================================================================================
		public const string COMMIT_HASH_TAG       = "#COMMIT_HASH#";       // コミットハッシュ置換対象のタグ
		public const string SHORT_COMMIT_HASH_TAG = "#SHORT_COMMIT_HASH#"; // コミットハッシュ（短縮版）置換対象のタグ

		//================================================================================
		// 関数（static）
		//================================================================================
		/// <summary>
		/// コミットハッシュを管理するスクリプトを生成します
		/// </summary>
		/// <example>
		/// <code>
		/// var outputPath = "Assets/Scripts/GitCommitHash.cs";
		/// 
		/// var template = $@"public static class GitCommitHash
		/// {{
		///     public const string COMMIT_HASH       = ""{GitCommitHashCodeGenerator.COMMIT_HASH_TAG}"";
		///     public const string SHORT_COMMIT_HASH = ""{GitCommitHashCodeGenerator.SHORT_COMMIT_HASH_TAG}"";
		/// }}
		/// ";
		///
		/// GitCommitHashCodeGenerator.Generate( outputPath, template );
		/// </code>
		/// </example>
		public static void Generate
		(
			string outputPath,
			string template
		)
		{
			// 出力先のフォルダが存在しない場合は作成します
			var dir = Path.GetDirectoryName( outputPath );

			if ( !Directory.Exists( dir ) )
			{
				Directory.CreateDirectory( dir );
			}

			// Git のコミットハッシュを読み込みます
			var commitHash      = GitCommitHashLoader.LoadCommitHash();
			var shortCommitHash = GitCommitHashLoader.LoadShortCommitHash();

			// コミットハッシュを埋め込んだスクリプトの文字列を作成します
			var code = template;

			code = code.Replace( COMMIT_HASH_TAG, commitHash );
			code = code.Replace( SHORT_COMMIT_HASH_TAG, shortCommitHash );

			// 作成した文字列をスクリプトとして保存します
			File.WriteAllText( outputPath, code );
			AssetDatabase.Refresh();
		}
	}
}