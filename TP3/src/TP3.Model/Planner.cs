namespace TP3.Model
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Planner
    {
        /// <summary>
        /// Devuelve una lista ordenada de tareas con el orden de ejecución.
        /// </summary>
        /// <remarks>
        /// El orden es O(NLogN + N(W + 1)) donde N es la cantidad de tareas y W es el vencimiento máximo.
        /// </remarks>
        /// <param name="tasks">Lista desordenada de tareas.</param>
        /// <returns>Plan de ejecucion.</returns>
        public static IEnumerable<Task> GetPlan(List<Task> tasks)
        {
            // O(n log n)
            var orderedTasks = tasks.OrderBy(t => t.Deadline).ToList();

            var maxDeadline = orderedTasks.Last().Deadline; // O(1)           
            //matriz para mantener los resultados
            var matrix = new int[orderedTasks.Count + 1, maxDeadline + 1];

            // O(N*W)
            for (var i = 1; i <= orderedTasks.Count; i++)
            {
                var task = orderedTasks[i - 1];
                // O(W)
                for (var deadline = 1; deadline <= maxDeadline; deadline++)
                {
                    var t = Math.Min(deadline, task.Deadline) - task.Duration;
                    if (t < 0)
                    {
                        // si no tengo tiempo entre el tiempo actual y el deadline de la tarea, 
                        // descarto la tarea (el beneficio no cambia)
                        matrix[i, deadline] = matrix[i - 1, deadline];
                    }
                    else
                    {
                        // si tengo tiempo entre el tiempo actual y el deadline de la tarea, 
                        // me quedo con el máximo entre el beneficio anterior o el actual mas el anterior en el otro tiempo.
                        matrix[i, deadline] = Math.Max(matrix[i - 1, deadline], task.Profit + matrix[i - 1, t]);
                    }
                }
            }

            // lista para devolver el plan.
            var plan = new List<Task>(orderedTasks.Count);

            // genero el plan a partir de la matriz de resultados - O(N)
            TraceBackPlan(orderedTasks.Count, maxDeadline, matrix, orderedTasks, plan);

            return plan;
        }

        /// <summary>
        /// Recorre la matriz de resultados, armando el plan. 
        /// </summary>
        /// <remarks>
        /// El orden es O(N). Se puede ver que la recursión siempre le resta 1 al indice de la tarea hasta llegar a 0.
        /// </remarks>
        /// <param name="taskIndex">Indice de la tarea.</param>
        /// <param name="deadline">Vencimiento.</param>
        /// <param name="M">Matriz de resultados.</param>
        /// <param name="tasks">lista de tareas.</param>
        /// <param name="plan">Lista con el plan.</param>
        private static void TraceBackPlan(int taskIndex, int deadline, int[,] M, List<Task> tasks, List<Task> plan)
        {
            if (taskIndex == 0)
            {
                return;
            }
            if (M[taskIndex, deadline] == M[taskIndex - 1, deadline])
            {
                TraceBackPlan(taskIndex - 1, deadline, M, tasks, plan);
            }
            else
            {
                var task = tasks[taskIndex - 1];
                var newDeadline = Math.Min(deadline, task.Deadline) - task.Duration;
                TraceBackPlan(taskIndex - 1, newDeadline, M, tasks, plan);

                plan.Add(task);
            }
        }
    }
}