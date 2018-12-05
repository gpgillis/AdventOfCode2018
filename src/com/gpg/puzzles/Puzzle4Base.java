package com.gpg.puzzles;

import static com.gpg.puzzles.Puzzle4Base.LogEntryType.FALLS_ASLEEP;
import static com.gpg.puzzles.Puzzle4Base.LogEntryType.GUARD;
import static com.gpg.puzzles.Puzzle4Base.LogEntryType.UNKNOWN;
import static com.gpg.puzzles.Puzzle4Base.LogEntryType.WAKES_UP;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.Hashtable;
import java.util.List;
import java.util.Map;
import java.util.TreeMap;

/**
 Advent Of Code Puzzle 4:
 http://adventofcode.com/2018/day/4

 Notes:

 1.  An example log entry is [1518-11-03 00:05] Guard #10 begins shift

 2.  The date-time portion is formatted yyyy-MM-dd hh:mm



 */
public abstract class Puzzle4Base extends PuzzleBase {

    protected enum LogEntryType {
        GUARD,
        FALLS_ASLEEP,
        WAKES_UP,
        UNKNOWN
    }

    protected boolean DataIsValid(ArrayList<String> inputData) {

        return ValidateMultiLineDataFile(inputData);
    }

    protected static LogEntryType getLogEntryType(String logEntry) {
        if (logEntry.contains("Guard #")) {
            return GUARD;
        }
        if (logEntry.contains("falls asleep")) {
            return FALLS_ASLEEP;
        }
        if (logEntry.contains("wakes up")) {
            return WAKES_UP;
        }

        return UNKNOWN;
    }

    protected static void updateDataStore(Map<String, Integer[]> store, String guardId, Integer startMin, Integer stopMin) {
        if (!store.containsKey(guardId)) {
            store.put(guardId, initializeMinuteArray());
        }

        Integer[] ma = store.get(guardId);

        for (int i = startMin; i < stopMin; i++) {
            ma[i] = ma[i] + 1;
        }

        store.put(guardId, ma);
    }

    protected static String getGuardId(String logEntry) throws IllegalArgumentException {
        if (getLogEntryType(logEntry) != GUARD) {
            throw new IllegalArgumentException("The log entry is not a GUARD type entry.");
        }

        String[] parsed = parseDataLine(logEntry);

        Integer poundIdx = parsed[1].indexOf("#");
        Integer stopIdx = parsed[1].indexOf(" ", poundIdx);

        return parsed[1].substring(poundIdx, stopIdx).trim();
    }

    protected static Integer getEntryMinute(String logEntry) throws IllegalArgumentException {

        if (getLogEntryType(logEntry) == UNKNOWN) {
            throw new IllegalArgumentException("The log entry is an UNKNOWN type entry.");
        }

        String [] parsed = parseDataLine(logEntry);

        Integer startIdx = parsed[0].indexOf(":");

        return Integer.parseInt(parsed[0].substring(startIdx + 1).trim());
    }

    protected static Long sumArray(Integer[] arr) {
        Long rtn = 0L;

        for (Integer i : arr) {
            rtn = rtn + i;
        }

        return rtn;
    }

    protected static Integer indexOfLargestValue(Integer[] arr) {
        Integer idx = -1;
        Integer max = -1;

        for (Integer i = 0; i < arr.length; i++) {
            if (arr[i] > max) {
                idx = i;
                max = arr[i];
            }
        }

        return idx;
    }

    protected static Map<Date, String> loadLogData(List<String> inputData) throws IllegalArgumentException {
        Map<Date, String> log = new TreeMap<Date, String>();

        for (String data : inputData) {
            String[] parsed = parseDataLine(data);
            Date dt = parseDateString(parsed[0]);
            if (dt == null) {
                throw new IllegalArgumentException("parseDate returned a null.");
            }
            log.put(dt, data);
        }

        return log;
    }

    private static Integer[] initializeMinuteArray() {
        Integer[] ma = new Integer[60];
        for (Integer i = 0; i < ma.length; i++) {
            ma[i] = 0;
        }

        return ma;
    }

    private static Date parseDateString(String dts) {
        SimpleDateFormat formatter = new SimpleDateFormat("yyyy-MM-dd hh:mm");  // [2]
        String strDate = dts;
        Date dt = null;

        try {
            dt = formatter.parse(strDate);
        }
        catch (ParseException e) {
            e.printStackTrace();
        }

        return dt;
    }

    private static String[] parseDataLine(String line) {
        Integer index = line.indexOf("] "); // [1]
        String[] rtn = new String[] {line.substring(0, index).replace("[","").replace("]", "").trim(), line.substring(index + 2).trim()};

        return rtn;
    }

    protected static long getTimeSpanMinutes(Date startDate, Date endDate) {
        long diffInSeconds = (endDate.getTime() - startDate.getTime()) / 1000;
        //long sec = (diffInSeconds >= 60 ? diffInSeconds % 60 : diffInSeconds);
        long min = (diffInSeconds = (diffInSeconds / 60)) >= 60 ? diffInSeconds % 60 : diffInSeconds;

        return min;
    }
}
