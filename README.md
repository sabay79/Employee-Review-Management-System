# E-Star
Employee Reviews Management System

## Features

### Department 
#### CRUD(if Admin else ReadOnly)
    ID
    Name

### Employee_Info 
#### CRUD(if Admin else ReadOnly)
    ID
    Name
    Designation
    Department_ID
    Employee_Review_ID  <to do>
    
### Categories (Review)
#### CRUD(if Admin else ReadOnly)
    ID
    Name
    
### Questions
#### CRUD(if Admin else ReadOnly)
    ID
    Question
    Categorey_ID
    Answer_ID <not sure>

### Answers
#### CRUD(if Admin else ReadOnly)
    ID
    Answer
    
### Review_Page
#### CRUD
    DepaertmentID
    EmmployeeID
    CategoryID 
    QuestionID
    
    - Calculates Department & Employee Review Score
    AnswerID
