using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeStudio.YiJing.Data;
using CodeStudio.YiJing.Entities;

namespace CodeStudio.YiJing.BO
{
	public class ArticleBO : BaseBO
	{
		private IArticleProvider provider;
		/// <summary>
		/// 
		/// </summary>
		public ArticleBO() {
			provider = (IArticleProvider)base.CreateProvider("Article");
		}
		/// <summary>
		/// 根据主键获取文章
		/// </summary>
		/// <param name="articleId">文章编号</param>
		/// <returns></returns>
		public Article Get(int articleId) {
			if (articleId <= 0)
				return null;

			return provider.Get(articleId);
		}
		/// <summary>
		/// 与指定文章的在同一大类的下一篇文章
		/// </summary>
		/// <param name="articleId">当前文章编号</param>
		/// <returns></returns>
		public Article GetNext(int articleId) {
			if (articleId <= 0) 
				return null;

			return provider.GetNext(articleId);
		}
		/// <summary>
		/// 与指定文章的在同一大类的上一篇文章
		/// </summary>
		/// <param name="articleId">当前文章编号</param>
		/// <returns></returns>
		public Article GetPrevious(int articleId) {
			if (articleId <= 0)
				return null;

			return provider.GetPrevious(articleId);
		}
		/// <summary>
		/// 获取当前文章的在整个分类中的分页信息
		/// </summary>
		/// <param name="articleId"></param>
		/// <returns></returns>
		public Pager<Article> GetPagedArticle( int articleId ) {
			if ( articleId <= 0 )
				return new Pager<Article>();

			return provider.GetPagedArticle( articleId );
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pageNo"></param>
		/// <param name="pageSize"></param>
		/// <param name="categoryId"></param>
		/// <param name="searchText"></param>
		/// <returns></returns>
		public Dictionary<int, int> GetStatistics( int pageNo, int pageSize, string searchText, params int[] categoryId ) {
			return provider.GetStatistics( pageNo, pageSize, searchText, categoryId );
		}
		/// <summary>
		/// 获取指定分类下的文章列表
		/// </summary>
		/// <param name="categoryId">文章所属分类，必须是正数</param>
		/// <returns></returns>
		public List<Article> Gets(int categoryId) {
			if (categoryId <= 0)
				return new List<Article>();

			return provider.Gets(categoryId);
		}
		/// <summary>
		/// 获取分页的文章列表
		/// </summary>
		/// <param name="pageNo">页码，从1开始</param>
		/// <param name="pageSize">每页大小，默认20</param>
		/// <param name="categoryId">文章所属分类，0或者负数表示不限分类</param>
		/// <param name="searchText">搜索内容，留空表示不限内容</param>
		/// <returns></returns>
		public Pager<Article> Gets( int pageNo, int pageSize, string searchText, params int[] categoryId ) {
			if (pageNo <= 0) pageNo = 1;
			if (pageSize <= 0) pageSize = 20;

			return provider.Gets(pageNo, pageSize, searchText, categoryId);
		}
		/// <summary>
		/// 保存或者更新文章
		/// </summary>
		/// <param name="item">需要保存的文章对象</param>
		/// <returns>返回文章编号</returns>
		public int SaveOrUpdate(Article item) {
			if (item == null) 
				return -1;

			return provider.SaveOrUpdate(item);
		}
		/// <summary>
		/// 删除文章，并且返回删除的总数
		/// </summary>
		/// <param name="articleId">文章编号</param>
		/// <returns></returns>
		public int Delete(int articleId) {
			if (articleId <= 0)
				return -1;

			return provider.Delete(articleId);
		}
	}
}
