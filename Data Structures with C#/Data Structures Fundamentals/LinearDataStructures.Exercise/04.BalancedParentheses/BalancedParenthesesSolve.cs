namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            if (parentheses.Length % 2 == 1 || string.IsNullOrEmpty(parentheses))
            {
                return false;
            }

            #region Without Stack
            //while (parentheses.Length > 0)
            //{
            //    char openingBracket = parentheses[0];
            //    char oppositeBracket = default;

            //    switch (openingBracket)
            //    {
            //        case '(': oppositeBracket = ')'; break;
            //        case '[': oppositeBracket = ']'; break;
            //        case '{': oppositeBracket = '}'; break;
            //        default: return false;
            //    }

            //    bool oppositeIsContained = parentheses.Contains(oppositeBracket);

            //    if (!oppositeIsContained)
            //    {
            //        return false;
            //    }

            //    parentheses = parentheses.Remove(0, 1);  
            //    parentheses = parentheses.Remove(parentheses.IndexOf(oppositeBracket), 1);
            //}
            #endregion
            #region With Stack
            Stack<char> openBrackets = new Stack<char>();

            foreach (var currentBracket in parentheses)
            {
                char expectedCharacter = default;

                switch (currentBracket)
                {
                    case ')': expectedCharacter = '('; break;
                    case ']': expectedCharacter = '['; break;
                    case '}': expectedCharacter = '{'; break;
                    default: openBrackets.Push(currentBracket); break;
                }

                if (expectedCharacter != default && openBrackets.Pop() != expectedCharacter)
                {
                    return false;
                }
            }
            #endregion

            return true;
        }
    }
}
