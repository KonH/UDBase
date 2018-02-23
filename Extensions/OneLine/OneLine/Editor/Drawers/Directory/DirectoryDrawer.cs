﻿using System;
using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace OneLine {
    internal class DirectoryDrawer : ComplexFieldDrawer {

        public DirectoryDrawer(DrawerProvider getDrawer) : base(getDrawer) {
        }

        protected override IEnumerable<SerializedProperty> GetChildren(SerializedProperty property){
            return property.GetChildren();
        }

        public override void AddSlices(SerializedProperty property, Slices slices){
            DrawHighlight(property, slices, 0, 1);
            base.AddSlices(property, slices);
        }

    }
}
