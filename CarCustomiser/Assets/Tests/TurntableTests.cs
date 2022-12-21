using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

    public class TurntableTests
    {
        [UnitySetUp]
        public IEnumerator Setup()
        {
            SceneManager.LoadScene("Main");
            yield return null;
            Debug.Log(SceneManager.GetActiveScene().name);
        }

        [UnityTest]
        public IEnumerator RotateClockwise()
        {   
            Setup();
            GameObject turntable = GameObject.Find("Turntable");

            turntable.GetComponent<Turntable>().RotateClockwise();
            yield return null;

            Assert.That(turntable.transform.rotation.y, Is.GreaterThan(0));
        }

        [UnityTest]
        public IEnumerator RotateAntiClockwise()
        {
            Setup();
            GameObject turntable = GameObject.Find("Turntable");
            turntable.GetComponent<Turntable>().RotateAntiClockwise();
            yield return null;

            Assert.That(turntable.transform.rotation.y, Is.LessThan(0));
        }
    }
