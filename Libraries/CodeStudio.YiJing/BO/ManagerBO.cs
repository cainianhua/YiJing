using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeStudio.YiJing.Data;
using CodeStudio.YiJing.Entities;

namespace CodeStudio.YiJing.BO
{
	public class ManagerBO : BaseBO
	{
		private IManagerProvider provider;

		public ManagerBO() {
			this.provider = ( IManagerProvider )base.CreateProvider( "Manager" );
		}

		public Manager Get( int managerId ) {
			if ( managerId <= 0 )
				return null;

			return provider.Get( managerId );
		}

		public Manager Get( string name ) {
			if ( string.IsNullOrEmpty( name ) ) {
				return null;
			}

			return provider.Get( name );
		}

		public List<Manager> Gets() {
			return provider.Gets();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public int SaveOrUpdate( Manager item ) {
			if ( item == null ) return -1;

			return provider.SaveOrUpdate( item );
		}
	}
}
