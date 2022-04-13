﻿using Planner.Models;
using Planner.Resolvers;

namespace Planner.Types
{
    public class AuthorType : ObjectType<Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            descriptor.Field(a => a.Id).Type<IdType>();
            descriptor.Field(a => a.FirstName).Type<StringType>();
            descriptor.Field(a => a.LastName).Type<StringType>();
            descriptor.Field<BlogPostResolver>(b => b.GetBlogPosts(default!, default!));
                //.Type<ListType<AuthorType>>().Name("GetBlogPosts"); // in this way if not possible to resolve child data then parent data return with error
        }
    }
}
