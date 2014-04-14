using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeStudio.YiJing.Entities;

namespace CodeStudio.YiJing.Data
{
    interface IArticleProvider
    {
		/// <summary>
		/// 根据主键获取文章
		/// </summary>
		/// <param name="articleId"></param>
		/// <returns></returns>
		Article Get(int articleId);
		/// <summary>
		/// 与指定文章的在同一大类的下一篇文章
		/// </summary>
		/// <param name="articleId"></param>
		/// <returns></returns>
		Article GetNext(int articleId);
		/// <summary>
		/// 与指定文章的在同一大类的上一篇文章
		/// </summary>
		/// <param name="articleId"></param>
		/// <returns></returns>
		Article GetPrevious(int articleId);
		/// <summary>
		/// 获取指定分类下的文章列表
		/// </summary>
		/// <param name="categoryId"></param>
		/// <returns></returns>
		List<Article> Gets(int categoryId);
		/// <summary>
		/// 获取当前文章的在整个分类中的分页信息。
		/// </summary>
		/// <param name="articleId"></param>
		/// <returns></returns>
		Pager<Article> GetPagedArticle( int articleId );
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pageNo"></param>
		/// <param name="pageSize"></param>
		/// <param name="categoryId"></param>
		/// <param name="searchText"></param>
		/// <returns></returns>
		Dictionary<int, int> GetStatistics( int pageNo, int pageSize, string searchText, params int[] categoryId );
		/// <summary>
		/// 获取分页的文章列表
		/// </summary>
		/// <param name="pageNo"></param>
		/// <param name="pageSize"></param>
		/// <param name="categoryId"></param>
		/// <param name="searchText"></param>
		/// <returns></returns>
		Pager<Article> Gets( int pageNo, int pageSize, string searchText, params int[] categoryId );
		/// <summary>
		/// 保存或者更新文章
		/// </summary>
		/// <param name="article"></param>
		/// <returns></returns>
		int SaveOrUpdate(Article article);
		/// <summary>
		/// 删除文章，并且返回删除的总数
		/// </summary>
		/// <param name="articleId"></param>
		/// <returns></returns>
		int Delete(int articleId);
    }
}
