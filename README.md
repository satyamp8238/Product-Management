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

 Web API Layer (ProductCategory.API)
ProductsController
•	CRUD Endpoints:
•	GET /api/products: Supports pagination, returns total count and total pages.
•	GET /api/products/{id}: Returns product by ID, 404 if not found.
•	POST /api/products: Adds a product, validates category existence and model state.
•	PUT /api/products/{id}: Updates a product, checks for ID match, existence, and category validity.
•	DELETE /api/products/{id}: Deletes a product, 404 if not found.
•	Validation:
•	Uses ModelState.IsValid for DTOs.
•	Checks for valid category before add/update.
•	Error Handling:
•	Returns appropriate HTTP status codes and error messages.
CategoriesController
•	CRUD Endpoints:
•	GET /api/categories: Returns all categories.
•	GET /api/categories/{id}: Returns category by ID, 404 if not found.
•	POST /api/categories: Adds a category, generates new GUID.
•	PUT /api/categories/{id}: Updates a category, checks for ID match.
•	DELETE /api/categories/{id}: Deletes a category if not in use.
•	Validation & Error Handling:
•	Checks for category-in-use before delete.
•	Returns clear status and messages.
API Project Setup
•	Swagger: Enabled in development for API testing.
•	Dependency Injection: Repositories and DbContext are registered.
•	HTTPS: Enforced.
•	Authorization: Middleware is present (though no policies are shown).
---
2. UI Layer (ProductCategory.UI)
Services
•	ProductService & CategoryService:
•	Use HttpClientFactory with a named client for API calls.
•	Implement async CRUD methods.
•	Handle API responses and errors robustly.
Controllers
•	ProductController & CategoryController:
•	Use services to interact with the API.
•	Validate model state before processing.
•	Return JSON responses for AJAX calls.
•	Support pagination and view models for listing.
Program.cs
•	Service Registration:
•	Registers services and HTTP client.
•	Configures JSON options for property naming.
•	Routing:
•	Sets up default controller route.
---
3. Microservices Considerations
•	Separation:
•	API and UI are in separate projects, a good step toward microservices.
•	Communication:
•	UI communicates with API via HTTP, not direct DB access.
•	Scalability:
•	Each service can be deployed/scaled independently.
•	Extensibility:
•	Easy to add more services (e.g., authentication, reporting) as separate APIs.
---
4. Recommendations
•	DTO Consistency:
•	Ensure all DTOs have validation attributes.
•	Error Logging:
•	Add logging for exceptions in API controllers.
•	Response Consistency:
•	Standardize API responses (e.g., always return a consistent envelope).
•	Security:
•	Implement authentication/authorization as needed.
•	Testing:
•	Add unit and integration tests for controllers and services.

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
