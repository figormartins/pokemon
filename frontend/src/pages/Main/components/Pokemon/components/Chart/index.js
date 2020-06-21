import React, { useState, useEffect, useCallback } from "react"
import { Radar } from "react-chartjs-2";
import { Container } from './styles'

import { apiV2 } from "../../../../../../services/api"

const Chart = ({ number, name, color }) => {
  const [stats, setStats] = useState([])
  const statsCallback = useCallback(async (number) => {
    const pokemon = await apiV2.get(`pokemon/${number}`)
    const stats = pokemon.data.stats.map(curr => {
      const obj = {
        name: formatLabel(curr.stat.name),
        base_stat: curr.base_stat
      }

      return obj
    })

    return stats
  }, [])

  const formatLabel = (str) => {
    if (str.length > 1) {
      const upper = str.charAt(0).toUpperCase() + str.slice(1)
      return upper.replace("-", " ")
    }

    return str.toUpperCase()
  }

  const options = {
    title: {
      display: true,
      text: `${name} Stats`
    },
    aintainAspectRatio: false,
    legend: false,
    scale: {
      angleLines: {
        display: false
      },
      ticks: {
        display: false,
        beginAtZero: true
      }
    },
    tooltips: {
      callbacks: {
        title: function (tooltipItem, data) {
          return data["labels"][tooltipItem[0]["index"]];
        },
        label: function (tooltipItem, data) {
          return data["datasets"][0]["data"][tooltipItem["index"]];
        }
      },
      backgroundColor: "#FFFFFFDD",
      titleFontSize: 16,
      titleFontColor: "#15172B",
      bodyFontColor: "#000",
      bodyFontSize: 14,
      displayColors: false
    },
    layout: {
      padding: {
        left: -120,
        right: 0,
        top: 0,
        bottom: 0
      }
    }
  }

  const data = {
    labels: stats.map(st => st.name),
    datasets: [
      {
        data: stats.map(st => st.base_stat),
        backgroundColor: `${color}55`,
        borderColor: color,
        pointBorderColor: "#fff",
        pointBackgroundColor: color,
        pointHoverBackgroundColor: color,
        pointHoverBorderColor: `${color}44`,
        fill: true
      }
    ]
  }

  useEffect(() => {
    if (number) {
      statsCallback(number)
        .then(data => setStats(data))
    }
  }, [number, statsCallback])

  return (
    <Container>
      <Radar data={data} options={options} />
    </Container>
  )
}

export default Chart
