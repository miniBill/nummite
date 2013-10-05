using ProtoBuf;
using System.Collections.Generic;
using Nummite.Shapes.Interfaces;
using System.Linq;

namespace Nummite.Model {
	[ProtoContract]
	class Document {
		public Document(IEnumerable<IShape> shapes) {
			Shapes = shapes.ToArray();
		}

		[ProtoMember(1)]
		public int Width { get; set; }

		[ProtoMember(2)]
		public int Height { get; set; }

		[ProtoMember(3, AsReference = true)]
		public IShape[] Shapes { get; set; }
	}
}
