using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmpInterpreter
{
    public class Memory
    {
        public MemorySlot Local { get; set; }
        private MemorySlot[] memory;

        public Memory (uint size)
        {
            Clear(size);
        }

        public void Clear(uint newSize)
        {
            Local = null;
            memory = new MemorySlot[newSize];

            for (int i = 0; i < memory.Length; ++i)
            {
                memory[i] = null;
            }
        }

        public void Set(MemoryType type, object value, uint index)
        {
            if (index >= memory.Length)
            {
                throw new IndexOutOfRangeException("Set");
            }

            memory[index] = new MemorySlot(type, value);
        }

        public MemorySlot Get(uint index)
        {
            if (index >= memory.Length)
            {
                throw new IndexOutOfRangeException("Get");
            }

            MemorySlot tmp = memory[index];
            if (tmp == null)
            {
                throw new InvalidOperationException(string.Format("Get: Memory at index `{0}` is null.", index));
            }
            else
            {
                return tmp;
            }
        }
    }

    public class MemorySlot
    {
        public MemoryType Type { get; private set; }
        private object Value { get; set; }

        public MemorySlot(MemoryType type, object value)
        {
            Type = type;
            Value = value;
        }

        public object GetValue(MemoryType type)
        {
            if (type != Type)
            {
                return null;
                // throw new InvalidOperationException("GetValue: Type mismatch.");
            }

            switch(type)
            {
                case MemoryType.Int:
                    return (int)Value;

                case MemoryType.Char:
                    return (char)Value;

                default:
                    throw new InvalidOperationException("GetValue: Invalid type.");
            }
        }
    }

    public enum MemoryType
    {
        Int,
        Char
    }
}
