
// function toggleCart() {
//     const cartOverlay = document.getElementById('cartOverlay');
//     if (cartOverlay.style.display === 'flex') {
//         cartOverlay.style.display = 'none';
//     } else {
//         cartOverlay.style.display = 'flex';
//     }
// }

async function LoadContent(){
    try {
        const headerResponse = await fetch('../pages/header.html');
        if (!headerResponse.ok) {
            throw new Error('Failed to fetch header');
        }
        const headerHtml = await headerResponse.text();
        document.getElementsByClassName('header')[0].innerHTML = headerHtml;
    } catch (error) {
        console.error('Error fetching header:', error);
    }
    
    try {
        const footerResponse = await fetch('../pages/footer.html');
        if (!footerResponse.ok) {
            throw new Error('Failed to fetch footer');
        }
        const footerHtml = await footerResponse.text();
        document.getElementsByClassName('footer')[0].innerHTML = footerHtml;
    } catch (error) {
        console.error('Error fetching footer:', error);
    }
}


document.addEventListener("DOMContentLoaded",async function() {
  
    await LoadContent();
    const sideMenu = document.querySelector(".side-menu");
    const menuToggle = document.querySelector(".menu-toggle");
    const closeBtn = document.querySelector(".close-btn");

    const cart = document.querySelector(".cart");
    const cartoverlay = document.querySelector(".cart-overlay");
    const cartbtn =  document.querySelector(".cart-btn");
    const closeBtn1 = document.querySelector(".close-cart");

    for(let i=1;i<=4;i++){
        const catbtn = document.querySelector(`.nav-btn${i}`);

        // catbtn.onclick = function() {
        //     const buttons = document.querySelectorAll('.categories-nav button');
        //     buttons.forEach(button => {
        //         button.classList.remove("active");
        //     });
        //     catbtn.classList.add("active");
        //     console.log(catbtn);
        // };
        catbtn.onclick = (function(btn) {
            return function() {
                const buttons = document.querySelectorAll('.categories-nav button');
                buttons.forEach(button => {
                    button.classList.remove("active");
                });
                btn.classList.add("active");
                console.log(btn);
            };
        })(catbtn);
    }

    const cartOverlay = document.getElementById('cartOverlay');
    const cartElement = cartOverlay.querySelector('.cart');
    const cartToggleBtn = document.querySelector('.cart-btn');
    const closeCartBtn = cartOverlay.querySelector('.close-cart');

    cartToggleBtn.addEventListener('click', function() {
        cartOverlay.classList.add('active');
        setTimeout(() => {
            cartElement.classList.add('active');
        }, 0); 
    });

    closeCartBtn.addEventListener('click', function() {
        cartElement.classList.remove('active');
        setTimeout(() => {
            cartOverlay.classList.remove('active');
        }, 300); 
    });

    //Menu Toggle Open Close
    menuToggle.addEventListener("click", function() {
        sideMenu.classList.add("open");
    });

    closeBtn.addEventListener("click", function() {
        sideMenu.classList.remove("open");
    });


    //Carousel 
    const carouselWrapper = document.querySelector(".carousel-wrapper");
    const slides = document.querySelectorAll(".carousel-slide");
    const prevButton = document.querySelector(".prev");
    const nextButton = document.querySelector(".next");
    let currentIndex = 0;
    const totalSlides = slides.length;

    function updateCarousel() {
        const offset = -currentIndex * 100;
        carouselWrapper.style.transform = `translateX(${offset}%)`;
    }

    prevButton.addEventListener("click", function() {
        currentIndex = (currentIndex > 0) ? currentIndex - 1 : totalSlides - 1;
        updateCarousel();
    });

    nextButton.addEventListener("click", function() {
        currentIndex = (currentIndex < totalSlides - 1) ? currentIndex + 1 : 0;
        updateCarousel();
    });
});
