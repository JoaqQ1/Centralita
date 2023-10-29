using System;
namespace Entidades
{
	public static class statica
	{
		public static int id;
		static statica()
		{
			statica.id = 2;
		}
		public static void AumentarId()
		{
			statica.id++;			
		}
	}
}

