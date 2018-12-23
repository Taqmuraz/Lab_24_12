using System;

namespace Laboratornaya
{
	public class SortOperation : Operation
	{
		public int swapsCount { get; protected set; }
		public int comparesCount { get; protected set; }

		public delegate SortToDo ArrayDo<T> (T[] array);
		public delegate void SortToDo (SortOperation operation);

		public SortOperation (SortToDo _toDo) : base ((Operation op) => _toDo((SortOperation)op))
		{
		}

		public void Swap ()
		{
			swapsCount++;
		}
		public void Compare ()
		{
			comparesCount++;
		}
	}

	public abstract class Operation
	{
		public delegate void ToDo (Operation operation);

		DateTime start;
		DateTime end;
		ToDo toDo;

		public Operation (ToDo _toDo)
		{
			toDo = _toDo;
		}

		public TimeSpan Do (Operation operation)
		{
			Start ();
			toDo (this);
			End ();
			return Time ();
		}
		void Start ()
		{
			System.Threading.Thread.Sleep (1);
			start = DateTime.Now;
		}
		void End ()
		{
			end = DateTime.Now;
		}
		TimeSpan Time ()
		{
			return (end - start);
		}
	}
}

