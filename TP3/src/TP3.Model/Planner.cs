using System;
using System.Linq;
using System.Collections.Generic;

namespace TP3.Model
{
	public class Planner
	{
		/// <summary>
		/// Este método recorre la matriz de resultados, armando el plan. 
		/// </summary>
		/// <remarks>
		/// El orden es O(N) Se puede ver que la recursión siempre le resta 1 al indice de la tarea hasta llegar a 0.
		/// </remarks>
		/// <param name="i">Indice de la tarea.</param>
		/// <param name="t">Vencimiento.</param>
		/// <param name="plan">Lista con el plan.</param>
		/// <param name="M">Matriz de resultados.</param>
		/// <param name="tasks">lista de tareas.</param>
		private static void TraceBackPlan(int i, int t, List<Task> plan, int[,] M, List<Task> tasks)
		{
			if (i == 0) return;
			if (M[i, t] == M[i - 1, t])
			{
				TraceBackPlan(i - 1, t, plan, M, tasks);
			}
			else
			{
				var task = tasks[i-1];
				var tt = Math.Min(t, task.Deadline) - task.Duration;
				TraceBackPlan(i - 1, tt, plan, M, tasks);
				// agrego la tarea al plan.
				plan.Add(task);
			}
		}

		/// <summary>
		/// Este método devuelve una lista ordenada de tareas con el orden de ejecución.
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
			// lista para devolver el plan.
			var plan = new List<Task>(orderedTasks.Count);                        
			var maxDeadline = orderedTasks.Last().Deadline; // O(1)           
			//matriz para mantener los resultados
			var M = new int[orderedTasks.Count+1, maxDeadline + 1]; 

			// O(N*W)
			for (var i = 1; i <= orderedTasks.Count; i++)
			{
				var task = orderedTasks[i-1];
				// O(W)
				for (var d = 1; d <= maxDeadline; d++)
				{ 
					var t = Math.Min(d, task.Deadline) - task.Duration;
					if (t < 0)
					{
						// si no tengo tiempo entre el tiempo actual y el deadline de la tarea, 
						// decarto la tarea - el beneficio no cambia
						M[i, d] = M[i-1, d];
					}
					else
					{
						// si tengo tiempo entre el tiempo actual y el deadline de la tarea, 
						// me quedo con el máximo entre el beneficio anterior o el actual mas el anterior en el otro tiempo.
						M[i, d] = Math.Max(M[i-1, d], task.Profit + M[i-1, t]);
					}
				}
			}
			// genero el plan a partir de la matriz de resultados - O(N)
			TraceBackPlan(orderedTasks.Count, maxDeadline, plan, M, orderedTasks);

			return plan;
		}
	}
}


