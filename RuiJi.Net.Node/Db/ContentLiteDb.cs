﻿using LiteDB;
using RuiJi.Net.Core.Utils.Page;
using RuiJi.Net.Node.Feed;
using RuiJi.Net.Node.Feed.LTS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuiJi.Net.Node.Db
{
    public class ContentLiteDb
    {
        public static void AddOrUpdate(ContentModel content, string shard)
        {
            using (var db = new LiteDatabase(@"LiteDb/Content/" + shard + ".db"))
            {
                var col = db.GetCollection<ContentModel>("contents");
                col.EnsureIndex(m => m.FeedId);
                col.EnsureIndex(m => m.Id);
                col.EnsureIndex(m => m.Url);

                if (content.Id == 0)
                {
                    var c = col.Find(m => m.Url == content.Url).FirstOrDefault();
                    if (c == null)
                    {
                        content.CDate = DateTime.Now;
                        col.Insert(content);
                        return;
                    }
                    content.Id = c.Id;
                }                   

                col.Update(content);
            }
        }

        public static List<ContentModel> GetModels(Paging page, string shard, int feedID = 0)
        {
            using (var db = new LiteDatabase(@"LiteDb/Content/" + shard + ".db"))
            {
                var col = db.GetCollection<ContentModel>("contents");

                page.Count = col.Count();

                if (feedID == 0)
                    return col.Find(Query.All()).OrderByDescending(m => m.Id).Skip(page.Start).Take(page.PageSize).ToList();
                else
                    return col.Find(m=>m.FeedId == feedID).OrderByDescending(m=>m.Id).Skip(page.Start).Take(page.PageSize).ToList();
            }
        }
    }
}