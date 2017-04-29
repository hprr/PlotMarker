﻿using System;
using TShockAPI;

namespace PlotMarker
{
	internal static class Extensions
	{
		public static T NotNull<T>(this T obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException(nameof(obj), $"类型为{typeof(T).FullName}对象不应为Null.");
			}

			return obj;
		}

		public static int GetMaxCells(this TSPlayer player)
		{
			if (!player.IsLoggedIn)
			{
				return 0;
			}
			if (player.HasPermission("pm.cell.infinite"))
			{
				return -1;
			}
			for (byte index = 20; index > 0; index++)
			{
				if (player.HasPermission("pm.cell." + index))
					return index;
			}
			return PlotMarker.Config.DefaultCellPerPlayer;
		}
	}
}
