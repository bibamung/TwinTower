using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 튜토리얼 표시 클래스
/// 튜토리얼마다 다른 스크립트를 보여주어야 하므로 TutorialObject로 생성한 튜토리얼을 받고, 이를 보여줌.
/// 추후 UI로 대체할 것임.
/// </summary>
public class Tutorial : MonoBehaviour {
    [SerializeField] private TutorialObject tutorialobject;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) {
            Debug.Log(tutorialobject.TutorialString);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) {
            Debug.Log("튜토리얼 없애기");
        }
    }
}