/* Copyright (C) 2008 Leonardo Taglialegne <leonardotaglialegne@gmail.com>
 *
 * This file is part of Nummite.
 *
 * Nummite is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * Nummite is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with Nummite.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Windows.Forms;
using Nummite.Forms;

namespace Nummite {
	static class Program
	{
		[STAThread]
		static void Main ()
		{
#if !DEBUG
			try {
#endif
				Application.EnableVisualStyles ();
				Application.SetCompatibleTextRenderingDefault (false);
				Application.Run (new MainForm ());
#if !DEBUG
			} catch (Exception e) {
				string error = string.Empty;
				try {
					string version = Encoding.UTF8.GetString (Resources.Version);
					version = "Version: " + version.Substring (0, version.Length - 1);
					error = Inspect (version, e);
				} catch {
					MessageBox.Show ("Error in Inspect! Please report this ASAP");
				}

				new ErrorForm (error).ShowDialog ();
			}
#endif

		}

		static string Inspect (string p, Exception e)
		{
			while (true) {
				if (e == null)
					return p;
				p += Environment.NewLine + Environment.NewLine + e.Message + Environment.NewLine + e.StackTrace;
				e = e.InnerException;
			}
		}
	}
}
