import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import ResponseiveAppBar from './ResponsiveAppBar'
import './App.css'

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <ResponseiveAppBar />
    </>
  )
}

export default App
