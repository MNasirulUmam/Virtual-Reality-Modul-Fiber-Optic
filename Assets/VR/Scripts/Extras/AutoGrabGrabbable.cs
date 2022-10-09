﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR {
    public class AutoGrabGrabbable : GrabbableEvents {
        public override void OnBecomesClosestGrabbable(Grabber touchingGrabber) {
            touchingGrabber.GrabGrabbable(grab);
        }
    }
}

