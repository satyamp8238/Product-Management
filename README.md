# 🛒 Product & Category Management Module

This module provides complete **CRUD functionality** for managing **products and categories** using **ASP.NET Core Web API** and **Razor Pages** in the same solution. It features a **responsive UI** built with **Bootstrap** and **jQuery**, and clean API integration using **Entity Framework Core**.

---

## 💻 Features

### 🔹 Product Management
- ✅ Add new products  
- ✅ Edit existing products  
- ✅ Delete products  
- ✅ Form validation  
- ✅ Modal UI using Bootstrap  
- ✅ jQuery AJAX-based interactions  
- ✅ Product list with category name display  
- ✅ Category dropdown integrated in product form  

### 🔹 Category Management
- ✅ Add new categories  
- ✅ Edit existing categories  
- ✅ Delete categories  
- ✅ Form validation  
- ✅ If a category is in use by any product, it **cannot be deleted** (validated in backend)  

---

## 🔧 Technologies Used

- 🧩 **ASP.NET Core Web API** (Backend)
- 🎨 **Razor Pages** (Frontend UI)
- 🗄️ **Entity Framework Core** (Database operations)
- 🛢️ **SQL Server** (Database)
- 💠 **Bootstrap 5** (Responsive UI)
- 💻 **jQuery** (Dynamic UI actions)
- 🧪 **Swagger** (API testing & documentation)

---

## 🔄 Backend & Frontend in One Solution

✅ Both **API** and **UI** are developed inside the same ASP.NET Core solution.  
This enables:
- Tight integration  
- Better maintainability  
- Easier deployment  
---

## 🔌 Web API & UI Architecture Overview
### 📦 Web API Layer (ProductCategory.API)
### 🔹 ProductsController – CRUD Endpoints
- GET /api/products: Supports pagination; returns product list with total count & total pages.
- GET /api/products/{id}: Returns product by ID; responds with 404 if not found.
- POST /api/products: Adds a new product after validating the category and model state.
- PUT /api/products/{id}: Updates product; validates ID match and category existence.
- DELETE /api/products/{id}: Deletes product; responds with 404 if product not found.

### ✅ Validation
- Uses ModelState.IsValid for DTO validation.
- Checks for valid CategoryId during add/update.

### ⚠️ Error Handling
- Returns appropriate HTTP status codes (400, 404, etc.)
- Sends descriptive error messages in failure cases.

### 🔹 CategoriesController – CRUD Endpoints
- GET /api/categories: Returns all categories.
- GET /api/categories/{id}: Returns category by ID; 404 if not found.
- POST /api/categories: Adds a new category with a new GUID.
- PUT /api/categories/{id}: Updates category; validates ID match.
- DELETE /api/categories/{id}: Deletes category if not in use.

### ✅ Validation & Error Handling
- Prevents deletion if category is used in products.
- Returns structured status & message on errors.

## ⚙️ API Project Setup
- Swagger: Enabled in development for testing and documentation.
- Dependency Injection: Services, Repositories, and DbContext are DI-registered.
- HTTPS: Enforced in API project.
- Authorization: Middleware present (configurable).

## 🖥️ UI Layer (ProductCategory.UI)
### 🔹 Services
- ProductService / CategoryService:
- Uses HttpClientFactory with named clients.
- Implements async CRUD API calls.
- Handles API error responses gracefully.

### 🔹 Controllers
- ProductController / CategoryController:
- Interacts with APIs via service layer.
- Uses model validation.
- Returns JSON for AJAX responses.
- Supports pagination using ViewModels.

🔧 Program.cs
- Registers HTTP client and services.
- Configures JSON serialization settings.
- Sets up default routing and MVC.

### 🧱 Microservices-Friendly Architecture
✅ Separation of Concerns: API and UI are two different projects within the same solution.
✅ HTTP Communication: UI talks to API via HttpClient, not direct DB access.
✅ Scalability: Each layer can be deployed/scaled independently.
✅ Extensibility: Easily extendable to add services like Auth, Reports, etc.

### 📈 Recommendations
- DTO Validation: Use [Required], [StringLength], and other annotations.
- Centralized Error Logging: Add structured logging with ILogger<T>.
- Standard API Responses: Use a consistent envelope { status, message, data }.
- Security Layer: Add authentication (JWT or Identity) if needed.
- Testing: Include unit & integration tests for API and service layers.

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

  ![image](https://github.com/user-attachments/assets/1ca6e14f-4367-4d9d-a39d-1140208c1949)

**Result:**

- Modal opens
- Fields pre-filled
- Title is "Edit Product"

![image](https://github.com/user-attachments/assets/48828db4-2e6e-4c1f-ba09-f3f4e1dd33e1)

---

### 5️⃣ Delete Product

**Action:** Click Delete button



**Result:**

- Confirmation dialog
- Product gets deleted
- Page reloads

![image](https://github.com/user-attachments/assets/82361d09-499e-4934-977f-abee1a3cf237)

---
### 6️⃣ Add Category 

**Action:** Click the Add Category button.

**Result:**
- Modal opens with title "Add New Category"
- All fields are empty
- Category form is ready for input

![image](https://github.com/user-attachments/assets/50497acb-3095-4834-8c16-be3ce3fa552b)

---
### 7️⃣ Edit Category

**Action:** Click the Edit Category button.

**Result:**
- Modal opens with title "Edit Category"
- Fields are pre-filled with selected category data
- User can update name/description and submit

![image](https://github.com/user-attachments/assets/182a84ea-ed64-40d7-a7d1-32ecdf0b70f0)

---
### 8️⃣ Delete Category

**Action:** Click the Delete Category button.

**Result:**
- A confirmation dialog appears
- If the category is not in use, it gets deleted successfully and page reloads
- If the category is in use, show error: "Category is in use and cannot be deleted."
  "Successful category delete confirmation"
  ![image](https://github.com/user-attachments/assets/8d0cb5b8-2ec6-4549-a13f-dde920959ff2)

  "Error alert for category in use"
  ![image](https://github.com/user-attachments/assets/bb50bca0-0f9a-41e0-a81b-caf3fee6ff29)


## 🧪 Test Cases
🔸 Product Module
Test Case No.	Description	Expected Result
TC01	Open Add Product Modal	Modal opens with empty fields & title set
TC02	Add Product with valid input	Product created, modal closes, page reloads
TC03	Add Product with missing fields	Validation error shown, modal stays open
TC04	Open Edit Product Modal	Modal pre-fills data and shows correct title
TC05	Edit Product	Product updates, success alert, reload page
TC06	Delete Product	Product deletes after confirmation

🔹 Category Module
Test Case No.	Description	Expected Result
TC07	Open Add Category Modal	Modal opens with empty fields & title set
TC08	Add Category with valid input	Category created, modal closes, page reloads
TC09	Add Category with missing fields	Validation error shown, modal stays open
TC10	Open Edit Category Modal	Modal pre-fills category data and shows title
TC11	Edit Category	Category updates, success alert, reload page
TC12	Delete Category	Category deletes after confirmation
TC13	Delete In-Use Category	API returns error message: "Category is in use and cannot be deleted."

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
