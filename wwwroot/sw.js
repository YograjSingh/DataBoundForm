const CACHE_NAME = 'blog_cache1';
const new_cache = 'netcache';
const urlsToCache = [
      '/css/site.css',
    '/js/site.js'
];




self.addEventListener('install', function (event) {
    // Perform install steps
    
    event.waitUntil(
        caches.open(CACHE_NAME)
            .then(function (cache) {
                console.log('cache is opened');
                return cache.addAll(urlsToCache);
            })
    );
});

//fetch response from cache

self.addEventListener('fetch', function (event) {
    event.respondWith(
        caches.match(event.request)
            .then(function (response) {
                // Cache hit - return response
                if (response) {
                    return response;
                }
                return fetch(event.request);
                
            }
            )
    );
});