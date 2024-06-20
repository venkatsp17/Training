document.addEventListener('DOMContentLoaded', () => {
    const homeLink = document.getElementById('home-link');
    const quotesLink = document.getElementById('quotes-link');
    const homeSection = document.getElementById('home');
    const quotesSection = document.getElementById('quotes');
    const quotesContainer = document.getElementById('quotes-container');
    const prevButton = document.getElementById('prev');
    const nextButton = document.getElementById('next');
    const exploreQuotesButton = document.getElementById('explore-quotes');
    const searchInput = document.getElementById('search');
    const sortOrderSelect = document.getElementById('sortOrder'); // Added

    let quotes = [];
    let currentPage = 1;
    const quotesPerPage = 5;
    let filteredQuotes = []; // Array to store filtered quotes

    homeLink.addEventListener('click', () => {
        transitionToPage(homeSection, quotesSection);
        document.body.style.backgroundColor = '#121212';
    });

    quotesLink.addEventListener('click', () => {
        transitionToPage(quotesSection, homeSection);
        document.body.style.backgroundColor = '#1e1e1e';
        loadQuotes();
    });

    exploreQuotesButton.addEventListener('click', () => {
        quotesLink.click();
    });

    const fetchQuotes = async () => {
        try {
            const response = await fetch('https://dummyjson.com/quotes');
            const data = await response.json();
            quotes = data.quotes;
            filteredQuotes = quotes; // Initially, filteredQuotes contains all quotes
            displayQuotes();
        } catch (error) {
            console.error('Error fetching quotes:', error);
        }
    };

    const displayQuotes = () => {
        quotesContainer.innerHTML = '';

        const startIndex = (currentPage - 1) * quotesPerPage;
        const endIndex = startIndex + quotesPerPage;

        // Sort filteredQuotes based on selected sortOrder
        sortQuotes();

        const quotesToDisplay = filteredQuotes.slice(startIndex, endIndex);

        if (quotesToDisplay.length === 0) {
            quotesContainer.innerHTML = '<p>No quotes found.</p>';
        } else {
            quotesToDisplay.forEach(quote => {
                const quoteElement = document.createElement('div');
                quoteElement.classList.add('quote-card');
                quoteElement.innerHTML = `
                    <p>"${quote.quote}"</p>
                    <p><em>- ${quote.author}</em></p>
                `;
                quotesContainer.appendChild(quoteElement);
            });
        }

        prevButton.disabled = currentPage === 1;
        nextButton.disabled = endIndex >= filteredQuotes.length;
    };

    const sortQuotes = () => {
        const sortOrder = sortOrderSelect.value;
        filteredQuotes.sort((a, b) => {
            const authorA = a.author.toLowerCase();
            const authorB = b.author.toLowerCase();
            if (sortOrder === 'asc') {
                if (authorA < authorB) return -1;
                if (authorA > authorB) return 1;
                return 0;
            } else if (sortOrder === 'desc') {
                if (authorA > authorB) return -1;
                if (authorA < authorB) return 1;
                return 0;
            }
        });
    };

    const searchQuotes = () => {
        const searchTerm = searchInput.value.trim().toLowerCase();
        filteredQuotes = quotes.filter(quote => {
            return quote.quote.toLowerCase().includes(searchTerm) ||
                   quote.author.toLowerCase().includes(searchTerm);
        });
        currentPage = 1; // Reset current page to 1 when performing a new search
        displayQuotes();
    };

    searchInput.addEventListener('input', searchQuotes);

    sortOrderSelect.addEventListener('change', () => {
        displayQuotes();
    });

    prevButton.addEventListener('click', () => {
        if (currentPage > 1) {
            currentPage--;
            displayQuotes();
        }
    });

    nextButton.addEventListener('click', () => {
        if ((currentPage * quotesPerPage) < filteredQuotes.length) {
            currentPage++;
            displayQuotes();
        }
    });

    const loadQuotes = async () => {
        if (quotes.length === 0) {
            await fetchQuotes();
        } else {
            displayQuotes();
        }
    };

    const transitionToPage = (showSection, hideSection) => {
        hideSection.classList.remove('active');
        setTimeout(() => {
            hideSection.classList.add('hidden');
            showSection.classList.remove('hidden');
            setTimeout(() => {
                showSection.classList.add('active');
            }, 10);
        }, 500);
    };

    transitionToPage(homeSection, quotesSection);
    document.body.style.backgroundColor = '#121212';
});
