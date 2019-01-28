using GraphQL.Language.AST;
using GraphQL.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Server.Rules
{
    public class AllowIntrospectionRule : IValidationRule
    {
        public INodeVisitor Validate(ValidationContext context)
        {
            List<string> blacklist = new List<string>() { "__schema", "__type" };

            return new EnterLeaveListener(_ =>
            {
                _.Match<Field>(
                    enter: field =>
                    {
                    if (blacklist.Contains(field.Name.ToLower()))
                        {
                            throw new Exception("Not Allowed");
                        }                    
                    });
            });
        }
    }
}
