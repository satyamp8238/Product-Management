# 🛒 Product Management Module

This module allows users to manage products with CRUD functionality (Create, Read, Update, Delete) using Razor Pages, jQuery, and Bootstrap modals.

---

## 💻 Features

- Add new products
- Edit existing products
- Delete products
- Form validation
- Modal UI with Bootstrap
- jQuery AJAX requests
- Category dropdown integration

---

## 🚀 Technologies Used

- ASP.NET Core Razor Pages
- Entity Framework Core
- Bootstrap 5
- jQuery
- SQL Server

---

## 📸 Screenshots & Flow

### 1️⃣ Open Add Product Modal

**Action:** Click on `Add Product` button.

**Result:**

- Modal opens with empty fields
- Modal title shows "Add New Product"
- Category dropdown loads from backend

![image](https://github.com/user-attachments/assets/a1a6980e-98c7-44d4-ae2a-21af6c01deaf)


---

### 2️⃣ Add Product With Valid Input

**Action:**

- Fill product name, price, description, and select category
- Click Submit

**Result:**

- Product saved
- Modal closes
- Success alert
- Page reloads

![image](https://github.com/user-attachments/assets/901e83c7-37a3-46be-b965-e9640735754e)


---

### 3️⃣ Validation Errors

**Action:**

- Leave required fields empty and submit

**Result:**

- Form validation messages appear
- Modal stays open
- category 
![image](https://github.com/user-attachments/assets/91d86f29-8c04-4a11-b716-8cc7d4354f5b)
- Product
![image](https://github.com/user-attachments/assets/aa6bcafb-d28c-4e1e-b812-7fc07514f962)


---

### 4️⃣ Edit Product

**Action:**

- Click Edit button on product list
- ![image](https://github.com/user-attachments/assets/37577bab-489f-4333-982d-94b05bca64ec)


**Result:**

- Modal opens
- Fields pre-filled
- Title is "Edit Product"

![image](https://github.com/user-attachments/assets/835effec-a772-49c2-982a-e3f0c6bfdcfe)


---

### 5️⃣ Delete Product

**Action:** Click Delete button

**Result:**

- Confirmation dialog
- Product gets deleted
- Page reloads

1. ![image](https://github.com/user-attachments/assets/b70b9819-b1c3-417f-bcbe-3346aca89af4)
2. ![image](https://github.com/user-attachments/assets/d14bcc2c-cd87-4f90-9536-cca1d50ca822)


---

## 🧪 Test Cases

| Test Case No. | Description                          | Expected Result                                |
|---------------|--------------------------------------|-------------------------------------------------|
| TC01          | Open Add Product Modal               | Modal opens with empty fields & title set      |
| TC02          | Add Product with valid input         | Product created, modal closes, page reloads    |
| TC03          | Add Product with missing fields      | Validation error shown, modal stays open       |
| TC04          | Open Edit Product Modal              | Modal pre-fills data and shows correct title   |
| TC05          | Edit Product                         | Product updates, success alert, reload page    |
| TC06          | Delete Product                       | Product deletes after confirmation             |

---

## ⚙️ Setup Instructions

1. Clone this repo
2. Run database migrations (`dotnet ef database update`)
3. Run the project using `dotnet run` or Visual Studio
4. Go to `/Products` page to test the flow

---

## 📬 Contact

For any issues or contributions:

**Satyam Prajapati**  
Email Address: Satyamp8238@gmail.com
