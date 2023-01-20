# DB
student 
enrollment 
teacher 
allocation
class
grade 


## Relations (pre erd)
student is in many classes and a class has many student (destructure into a weak entity to avoid MTM relationship),
a teacher can teach many classes and a class may have many teachers(destructure into a weak entity to avoid MTM relationship),
a student can have a grade for each class they are in. 


student -> enrollment -> Class
teacher -> allocation -> Class
grade -> class & grade -> student

## Dummy Data ToDo
- Make 2 teachers 
- Make 10 Students 
- Make 6 classes  

then doneski (hopefully)