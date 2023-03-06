// Game4Automation (R) Framework for Automation Concept Design, Virtual Commissioning and 3D-HMI
// (c) 2019 in2Sight GmbH - Usage of this source code only allowed based on License conditions see https://game4automation.com/lizenz  

using UnityEngine;
using NaughtyAttributes;

namespace game4automation
{
    public abstract class LogicStep : MonoBehaviour
    {
        public string Name;
        
        [HideIf("NonBlocking")] [ProgressBar(100, EColor.Green)]
        public float State = 0;
        [HideInInspector] public bool StepActive = false;
        private LogicStep nextstep;
        
        // Needs to be implemented
        protected abstract void OnStarted();
        
        // Is called to proceed to next step
        protected void NextStep()
        {
            State = 0;
            StepActive = false;
            nextstep.StartStep();
        }

        protected bool NonBlocking()
        {
            return false;
        }
        
        // Is called to proceed to next step with certain name (jump)
        protected void NextStep(string name)
        {
            var steps = GetComponents<LogicStep>();
            foreach (var step in steps)
            {
                if (step.Name == name)
                    step.StartStep();
                return;
            }
        }

        public void StartStep()
        {
            State = 100;
            StepActive = true;
            OnStarted();
        }

        protected void Start()
        {
            StepActive = false;
            var steps = GetComponents<LogicStep>();
            bool tostart = false;
            for (int i = 0; i < steps.Length; i++)
            {
                if (steps[i] == this)
                {
                    if (i == 0)
                        tostart = true;
                    if (i < steps.Length - 1)
                    {
                        nextstep = steps[i + 1];
                        
                    }
                    else
                    {
                        nextstep = steps[0];
                        
                    }
                }
            }
            if (tostart)
                StartStep();
            
        }
    }
}
