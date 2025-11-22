using Godot;
using System;
using System.Data;

namespace Calculator
{
    public interface IKey { }

    public enum KeyType
    {
        Token, Value, Operator, Command
    }
    public enum Command
    {
        AddPint, BackSpace, Clear, Equal
    }

    public class CalKey
    {
        public readonly int ID;
        public readonly string InputText;
        protected KeyType Type;

        public CalKey(int id, string input)
        {
            ID = id;
            InputText = input;
            Type = SetKeyType();
        }

        public event Action<KeyType, Token> OnClicked;

        public virtual void Clicked()
        {
            Token token = new Token();
            EventInvoken(token);
        }

        protected void EventInvoken(Token token)
        {
            if (token.IsEmpty())
                token.Input(InputText);
            OnClicked.Invoke(Type, token);
        }

        protected virtual KeyType SetKeyType()
        {
            return KeyType.Token;
        }

        public void Clear()
        {
            OnClicked = null;
        }

        public KeyType GetKeyType() => Type;

        public virtual Token GetToken()
        {
            Token token = new Token();
            return token;
        }

    }


    public class ValueKey : CalKey
    {
        public ValueKey(int id, string input) : base(id, input)
        {

        }

        public override void Clicked()
        {
            var token = new TokenValue();
            EventInvoken(token);
        }

        protected override KeyType SetKeyType()
        {
            return KeyType.Value;
        }
    }

    public class OperatorDoubleKey : CalKey
    {
        public DoubleOperatorType OperatorType;

        public OperatorDoubleKey(int id, string input, DoubleOperatorType operatortype) : base(id, input)
        {
            OperatorType = operatortype;
        }

        public override void Clicked()
        {
            var token = new TokenOperatorDouble();
            token.OperatorType = OperatorType;
            EventInvoken(token);
        }

        protected override KeyType SetKeyType()
        {
            return KeyType.Operator;
        }
    }

    public class CommandKey : CalKey
    {
        public Command CommandType;

        public CommandKey(int id, string input, Command commandtype) : base(id, input)
        {
            CommandType = commandtype;
        }

        public override void Clicked()
        {
            var token = new Token();
            token.Input(CommandType.ToString());
            EventInvoken(token);
        }

        protected override KeyType SetKeyType()
        {
            return KeyType.Command;
        }
    }
}
