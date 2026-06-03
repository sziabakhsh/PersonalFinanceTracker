import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import { QueryClientProvider } from '@tanstack/react-query'

import './index.css'
import App from './App.tsx'

import { AccountContextProvider } from './context/AccountContext.tsx'
import { queryClient } from './lib/queryClient.tsx'

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <QueryClientProvider client={queryClient}>
      <AccountContextProvider>
        <App />
      </AccountContextProvider>
    </QueryClientProvider>
  </StrictMode>,
)