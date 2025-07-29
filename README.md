# 🎬 MVC HollyView

MVC HollyView is a small showcase project built with ASP.NET Core and C#. It demonstrates the Model-View-Controller architecture while integrating .NET Identity for authentication. Administrator (first user added to database gets admin role) can view, edit, and create movie entries. Users can update movie entries. Anonymous peole can view the movies and details. Image upload and update functionaity.

## 🚀 Features


- User login and registration with ASP.NET Identity
- Full CRUD operations for movies for the administrator
- Edit movies for logged in users
- Image upload to database
- Razor Views for UI rendering
- Simple and clean layout with HTML & CSS

## 📁 Project Structure

- `Controllers/` – Handles requests and actions
- `Models/` – Movie class with title, genre, and release date
- `Views/` – Razor pages for displaying movie data
- `Areas/Identity/Pages/` – Authentication views
- `Data/` – Entity Framework DbContext and migrations
- `wwwroot/` – Static content (CSS, JS)

## 🧰 Technologies Used

| Technology            | Purpose               |
|-----------------------|-----------------------|
| ASP.NET Core MVC      | Backend & structure   |
| Entity Framework Core | Data access           |
| Razor Pages           | UI rendering          |
| HTML/CSS              | Layout and styling    |
| .NET Identity         | Authentication        |
| JQuery& ajax          | Image handling        |

## 🛠 Getting Started

1. Clone the repository  
   ```bash
   git clone https://github.com/GnomezHub/MVC-HollyView.git

Movie list:
<img width="1365" height="839" alt="movies_list" src="https://github.com/user-attachments/assets/d20e9883-8826-4acd-b3d3-b784a77c586d" />

Movie details:
<img width="964" height="863" alt="movies_details" src="https://github.com/user-attachments/assets/23e4135b-d1c1-42dc-8f50-e00c1784c908" />

Acces denied:

<img width="1893" height="671" alt="acces_denied" src="https://github.com/user-attachments/assets/83206d8b-a5ed-4631-9d26-e13436029597" />
