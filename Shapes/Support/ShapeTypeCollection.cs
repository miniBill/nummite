using System.Collections.Generic;
using System.Drawing;
using System;
using System.Collections;

namespace Nummite.Shapes.Support {
	class ShapeTypeCollection<T> : IEnumerable<ShapeType<T>> {
		readonly List<ShapeType<T>> shapeTypes = new List<ShapeType<T>>();

		public IEnumerator<ShapeType<T>> GetEnumerator() {
			return shapeTypes.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

		public ShapeType<T> Add<TChild>(string description, Image image) where TChild : T, new() {
			return Add(() => new TChild(), description, image);
		}

		public ShapeType<T> Add(Func<T> constructor, string description, Image image) {
			var toret = new ShapeType<T>
			{
				Constructor = constructor, 
				Description = description, 
				Image = image
			};
			shapeTypes.Add(toret);
			return toret;
		}
	}
}
