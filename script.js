// wwwroot/script.js
document.addEventListener('DOMContentLoaded', function () {
  const container = document.getElementById('invoice-container');

  function showError(msg) {
    console.error(msg);
    container.innerHTML = `<div style="color:crimson;">Failed to load invoice: ${msg}</div>`;
  }

  // If your UI is hosted separately from the API, set apiBase to the full URL:
  // const apiBase = 'https://localhost:5001';
  // If UI is served by the same origin as API (recommended), keep empty string:
  const apiBase = '';

  const url = `${apiBase}/api/invoice`;

  // show loading
  container.innerText = 'Loading invoice...';

  fetch(url)
    .then(async resp => {
      // helpful debug info
      console.log('Fetch status:', resp.status, resp.statusText, 'URL:', url);

      if (!resp.ok) {
        // try to show API response body (if any)
        let text;
        try { text = await resp.text(); } catch { text = '<no body>'; }
        throw new Error(`HTTP ${resp.status} - ${text}`);
      }
      return resp.json();
    })
    .then(data => {
      console.log('Invoice payload:', data);
      if (!data) {
        showError('Empty response body');
        return;
      }

      // tolerate either camelCase or PascalCase fields
      const customerName = data.customerName ?? data.customername ?? data.CustomerName ?? '';
      const items = data.items ?? data.Items ?? [];

      if (!Array.isArray(items) || items.length === 0) {
        container.innerHTML = `<div>No items found for invoice (customer: ${customerName})</div>`;
        return;
      }

      let html = `<h2>Customer: ${customerName}</h2>`;
      html += '<ul>';
      items.forEach(item => {
        const name = item.name ?? item.Name ?? '(no name)';
        const price = item.price ?? item.Price ?? 0;
        html += `<li>${name} - $${price}</li>`;
      });
      html += '</ul>';
      container.innerHTML = html;
    })
    .catch(err => {
      showError(err.message ?? String(err));
    });
});
