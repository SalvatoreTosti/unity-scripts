using UnityEngine;
using System.Collections;

public interface IPipeableEffect {

	void PipelineInitialize(GameObject caster, GameObject target);
	IEnumerator PipelineTrigger();
	Stats.StatList Pipe (Stats.StatList statList);

}
