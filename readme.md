# Linq    

## Key Words    
+ Filter       
    - from
    - in   
    - where
+ Order       
    - orderby     
    - descending    
    - ascending     
+ Projecting        
    - select      
+ Join       
    - join      
    - in      
    - on     
+ Group      
    - group         
    - by
    - into        
+ Aggregate         
    - Aggregate      
+ Others        
    - equals   
    - let
+ Most userful   
    - from * in * where * select *

## Examples                 
```
var innerJoinQuery =
            from category in categories
            join prod in products on category.ID equals prod.CategoryID
            select new { ProductName = prod.Name, Category = category.Name };
```

```
var earlyBirdQuery =
            from sentence in strings
            let words = sentence.Split(' ')
            from word in words
            let w = word.ToLower() //How to use "let"
            where w[0] == 'a' || w[0] == 'e'
                || w[0] == 'i' || w[0] == 'o'
                || w[0] == 'u'
            select word;
```

## Demo             
> Requirement: Get ranks of student by credit and score.    

+ Linq to CSV     
+ Linq to XML                  
    - xdocument     
    ![](https://github.com/xiong-ang/LINQDemo/blob/master/XML.PNG?raw=true)
    - [xdocument & xmldocument](https://www.cnblogs.com/HQFZ/p/4788428.html)      
    - [xnamespace](http://www.w3school.com.cn/xml/xml_namespaces.asp)
+ Linq to EF          
    - [IQueryable<T> &  IEnumerable<T>](https://www.cnblogs.com/zgqys1980/p/4047315.html)
