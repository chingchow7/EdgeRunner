using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageUnitScript : MonoBehaviour {
	private bool initialized = false;
	private List<BlockSet> blockSetList = new List<BlockSet> ();

	// Use this for initialization
	void Start () {
		//
		// Store all Block Sets
		//
		foreach (Transform child in this.transform) {
			List<GameObject> blocks = new List<GameObject> ();
			if (child.name.Contains ("Column")) {
				foreach (Transform child2 in child) {
					blocks.Add (child2.gameObject);
				}
			}
			blockSetList.Add (new BlockSet(blocks));
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!initialized) {
			setupBlocks ();
			initialized = true;
		}
	}

	public void setupBlocks() {
		foreach (BlockSet set in blockSetList) {
			set.activateBlocks ();
			set.deactivateBlocks ();
		}
	}
}

public class BlockSet {
	private List<GameObject> blockList;

	public BlockSet (List<GameObject> blockList) {
		this.blockList = blockList;
	}

	public void activateBlocks () {
		foreach (GameObject block in blockList) {
			block.SetActive (true);
		}
	}

	public void deactivateBlocks () {
		int deactivateIndex = Random.Range(0, 3);

		blockList [deactivateIndex].SetActive (false);
	}
}
