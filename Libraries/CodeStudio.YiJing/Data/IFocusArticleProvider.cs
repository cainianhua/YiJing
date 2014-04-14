using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeStudio.YiJing.Entities;

namespace CodeStudio.YiJing.Data
{
    interface IFocusArticleProvider
    {
		FocusArticle Get(int faId);

		List<FocusArticle> Gets();

		int SaveOrUpdate(FocusArticle fa);

		int Delete(int faId);
    }
}
