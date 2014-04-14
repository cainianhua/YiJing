using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeStudio.YiJing.Entities;

namespace CodeStudio.YiJing.Data
{
	interface IManagerProvider
	{
		Manager Get( int mangerId );
		Manager Get( string name );

		List<Manager> Gets();

		int SaveOrUpdate( Manager item );
	}
}
